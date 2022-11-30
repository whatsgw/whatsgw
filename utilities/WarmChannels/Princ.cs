using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

using System.Net;
using System.Threading;
using log4net;
using System.IO;
using IniParser;

namespace WarmChannels
{
    public partial class Princ : Form
    {

        private static log4net.ILog log;
        string apikey = "";
        string[] numeros;
        string[] frases;

        int max_sleep = 0;
        int min_sleep = 0;
        bool service_started = false;

        public Princ()
        {
            InitializeComponent();

            log4net.Config.XmlConfigurator.Configure();

            try
            {
                var parser = new FileIniDataParser();
                var data = parser.ReadFile("cfg.ini");

                if (!string.IsNullOrEmpty(data["dados"]["apikey"]))
                {
                    txtapikey.Text = data["dados"]["apikey"];
                    txtnumeros.Text = data["dados"]["numeros"].Replace("|", "\r\n");
                    txtfrases.Text = data["dados"]["frases"].Replace("|", "\r\n");
                    txtmax_sleep.Text = data["dados"]["max_sleep"];
                    txtmin_sleep.Text = data["dados"]["min_sleep"];

                }

            }
            catch { }

        }



        public enum EnumLogLevel
        {
            Debug
    , Info
    , Error
    , Warn
        }

        private void W(EnumLogLevel enumLogLevel, string msg)
        {
            try
            {

                if (log == null) log = LogManager.GetLogger("burn");

                if (enumLogLevel.Equals(EnumLogLevel.Info) && log.IsInfoEnabled)
                    log.Info(msg);
                else if (enumLogLevel.Equals(EnumLogLevel.Warn) && log.IsWarnEnabled)
                {
                    log.Warn(msg);
                    //WriteToDB(enumLogLevel,msg);
                }
                else if (enumLogLevel.Equals(EnumLogLevel.Error))
                {
                    log.Error(msg);
                    //WriteToDB(enumLogLevel, msg);
                }
                else if (log.IsDebugEnabled)
                    log.Debug(msg);

            }
            catch (Exception ex)
            {
                string x = ex.Message.ToString();
                // n�o faz nada mesmo
            }

            if (InvokeRequired)
                this.Invoke(new Action<string>(toScreen), new object[] { msg });
            else
                toScreen(msg);

        }

        public void toScreen(string msg)
        {
            txtlog.Text = msg + "\r\n" + txtlog.Text;
            txtlog.Refresh();
            Application.DoEvents();
        }

        public static string DumpException(Exception ex, bool simple = false)
        {
            string s = "";

            //esse erro sempre acontece quando é feito um redirect em alguns momentos no aspx
            if (simple && ex.GetType().IsAssignableFrom(typeof(System.Threading.ThreadAbortException)))
                simple = false;

            //catch (System.Threading.ThreadAbortException ex)

            if (simple && log != null && !log.IsDebugEnabled)
                simple = true;

            if (simple)
                s = $"ex:{ex.Message}";
            else
                s = $"ex:{ex.ToString()}\n{ex.StackTrace}";

            return s;
        }

        public enum E_mensagem_tipo
        {
            Texto = 1,
            Media = 99,

        }

        public enum e_w_mensagem_tipo
        {
            text = 1
    , image = 2
    , video = 3
    , document = 4
    , file = 5
    , vcard = 6
    , audio = 7
    , ptt = 8
    , location = 9
        }

        private void BurnChannel(string numero)
        {

            W(EnumLogLevel.Info, $"{numero} BurnChannel...OK");

            var to_idx = new Random().Next(-1, numeros.Length);
            var message_idx = new Random().Next(-1, frases.Length); ;

            while (service_started)
            {
                var sleep = new Random().Next(min_sleep, max_sleep);

                try
                {
proximoNumero:
                    to_idx++;

                    if (to_idx > numeros.Length - 1)
                        to_idx = 0;

                    var to = numeros[to_idx].Replace("\r", "");
                    if (to == numero)
                        goto proximoNumero;

                    message_idx++;
                    if (message_idx > frases.Length - 1)
                        message_idx = 0;

                    var message = frases[message_idx].Replace("\r", "");

                    string ret = Send(apikey, numero, to, "", E_mensagem_tipo.Texto, message, "", "", "", DateTime.Now, true);
                    W(EnumLogLevel.Info, $"{numero} New message to [{to}] ret [{ret}] message [{message}]");

                }
                catch (Exception ex)
                {
                    W(EnumLogLevel.Error, $"{numero} BurnChannel...{DumpException(ex)}");
                }

                W(EnumLogLevel.Info, $"{numero} Sleeping...{sleep}");
                Application.DoEvents();
                Thread.Sleep(sleep);

            }

            W(EnumLogLevel.Info, $"{numero} BurnChannel...FIM");

        }

        public static string Send(string apikey,
    string phone_number,
    string contact_phone_number,
    string message_custom_id,
    E_mensagem_tipo mensagem_tipo,
    string message_body,
    string folder,
    string message_body_filename,
    string message_caption,
    DateTime agenda,
    bool check_status)
        {


            var qscoll = new System.Collections.Specialized.NameValueCollection();


            qscoll.Add("apikey", apikey);
            qscoll.Add("phone_number", phone_number);
            qscoll.Add("contact_phone_number", contact_phone_number);
            qscoll.Add("message_custom_id", message_custom_id);
            qscoll.Add("schedule", agenda.ToString("yyyy/MM/dd HH:mm:ss"));
            qscoll.Add("check_status", check_status ? "1" : "0");


            if (mensagem_tipo == E_mensagem_tipo.Texto)
            {
                qscoll.Add("message_type", ((int)e_w_mensagem_tipo.text).ToString());
                qscoll.Add("message_body", message_body);
            }
            else
            {
                string base64 = FileToBase64(folder + message_body_filename);
                var mime = GetMimeTypeFromFilenameOrFullPath(message_body_filename);
                //var fileextension = Geral.GetExtensionByMimeType(mime);

                qscoll.Add("message_type", ((int)e_w_mensagem_tipo.file).ToString());
                qscoll.Add("message_caption", message_caption);
                qscoll.Add("message_body_mimetype", mime);
                qscoll.Add("message_body_filename", message_body_filename);
                qscoll.Add("message_body", base64);
            }

            return Call("https://app.whatsgw.com.br/api/WhatsGw/Send", qscoll);

        }

        public static string GetMimeTypeFromFilenameOrFullPath(string fileNameOrFullPath)
        {

            string fileName = System.IO.Path.GetFileName(fileNameOrFullPath);

            return "";//System.Web.MimeMapping.GetMimeMapping(fileName);

        }

        public static string FileToBase64(string path)
        {
            Byte[] bytes = File.ReadAllBytes(path);
            String file = Convert.ToBase64String(bytes);
            return file;

        }

        public static string Call(string url, System.Collections.Specialized.NameValueCollection parameters, string method = "POST")
        {
            var client = new System.Net.WebClient();

            string responseString = "";
            byte[] response_data;
            try
            {
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                response_data = client.UploadValues(url, method, parameters);
                responseString = UnicodeEncoding.UTF8.GetString(response_data);
                return responseString;
            }
            catch (WebException wex)
            {
                throw new Exception(GetWebException(wex));
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static string GetWebException(WebException wex)
        {
            string responseString = wex.Message;


            if (wex.Response != null)
            {
                using (var errorResponse = (HttpWebResponse)wex.Response)
                {
                    using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                    {
                        responseString += "|" + reader.ReadToEnd();
                    }
                }
            }

            return responseString;
        }

        private void IniciarThreads()
        {

            try
            {

                apikey = txtapikey.Text;
                numeros = txtnumeros.Text.Split('\n');
                frases = txtfrases.Text.Split('\n');

                max_sleep = int.Parse(txtmax_sleep.Text);
                min_sleep = int.Parse(txtmin_sleep.Text);

                var parser = new FileIniDataParser();
                var data = (new FileIniDataParser()).ReadFile("cfg.ini");
                data["dados"]["apikey"] = apikey;
                data["dados"]["numeros"] = txtnumeros.Text.Replace("\r\n", "|");
                data["dados"]["frases"] = txtfrases.Text.Replace("\r\n", "|");
                data["dados"]["max_sleep"] = max_sleep.ToString();
                data["dados"]["min_sleep"] = min_sleep.ToString();
                parser.WriteFile("cfg.ini", data);

                foreach (var n in numeros)
                {

                    W(EnumLogLevel.Info, $"Criando...{n}");
                    var trde = new Thread(() => BurnChannel(n.Replace("\r", "")));
                    trde.IsBackground = true;
                    trde.SetApartmentState(ApartmentState.MTA);
                    trde.Name = $"BurnChannel {n}";
                    trde.Start();

                    Application.DoEvents();
                    Thread.Sleep(new Random().Next(500, 15000));
                }

                W(EnumLogLevel.Info, "Iniciando... FIM");

            }
            catch (Exception ex)
            {
                W(EnumLogLevel.Error, $"Iniciando...{DumpException(ex)}");
                MessageBox.Show($"Iniciando...{DumpException(ex)}");
            }

        }

        private void btniniciar_Click_1(object sender, EventArgs e)
        {
            try
            {

                service_started = true;

                btniniciar.Enabled = false;
                btnparar.Enabled = true;

                W(EnumLogLevel.Info, "Iniciando...");


                var trde = new Thread(() => IniciarThreads());
                trde.IsBackground = true;
                trde.SetApartmentState(ApartmentState.MTA);
                trde.Name = $"IniciarThreads";
                trde.Start();
                
            }
            catch (Exception ex)
            {
                W(EnumLogLevel.Error, $"Iniciando...{DumpException(ex)}");
            }
        }

        private void btnparar_Click_1(object sender, EventArgs e)
        {

            service_started = false;

            btniniciar.Enabled = true;
            btnparar.Enabled = false;

        }
    }
}
