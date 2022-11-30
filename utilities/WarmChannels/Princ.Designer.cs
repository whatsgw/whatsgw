
namespace WarmChannels
{
    partial class Princ
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Princ));
            this.txtmax_sleep = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtlog = new System.Windows.Forms.TextBox();
            this.btnparar = new System.Windows.Forms.Button();
            this.btniniciar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtfrases = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnumeros = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtapikey = new System.Windows.Forms.TextBox();
            this.txtmin_sleep = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtmax_sleep
            // 
            this.txtmax_sleep.Location = new System.Drawing.Point(493, 43);
            this.txtmax_sleep.Name = "txtmax_sleep";
            this.txtmax_sleep.Size = new System.Drawing.Size(70, 20);
            this.txtmax_sleep.TabIndex = 21;
            this.txtmax_sleep.Text = "120000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Intervalo Entre Mensagens(ms):";
            // 
            // txtlog
            // 
            this.txtlog.Location = new System.Drawing.Point(18, 512);
            this.txtlog.Multiline = true;
            this.txtlog.Name = "txtlog";
            this.txtlog.Size = new System.Drawing.Size(1286, 226);
            this.txtlog.TabIndex = 19;
            // 
            // btnparar
            // 
            this.btnparar.Enabled = false;
            this.btnparar.Location = new System.Drawing.Point(1220, 37);
            this.btnparar.Name = "btnparar";
            this.btnparar.Size = new System.Drawing.Size(75, 23);
            this.btnparar.TabIndex = 18;
            this.btnparar.Text = "Parar";
            this.btnparar.UseVisualStyleBackColor = true;
            this.btnparar.Click += new System.EventHandler(this.btnparar_Click_1);
            // 
            // btniniciar
            // 
            this.btniniciar.Location = new System.Drawing.Point(1139, 36);
            this.btniniciar.Name = "btniniciar";
            this.btniniciar.Size = new System.Drawing.Size(75, 23);
            this.btniniciar.TabIndex = 17;
            this.btniniciar.Text = "Iniciar";
            this.btniniciar.UseVisualStyleBackColor = true;
            this.btniniciar.Click += new System.EventHandler(this.btniniciar_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Mensagens:";
            // 
            // txtfrases
            // 
            this.txtfrases.Location = new System.Drawing.Point(183, 91);
            this.txtfrases.Multiline = true;
            this.txtfrases.Name = "txtfrases";
            this.txtfrases.Size = new System.Drawing.Size(1121, 415);
            this.txtfrases.TabIndex = 15;
            this.txtfrases.Text = resources.GetString("txtfrases.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Números:";
            // 
            // txtnumeros
            // 
            this.txtnumeros.Location = new System.Drawing.Point(18, 91);
            this.txtnumeros.Multiline = true;
            this.txtnumeros.Name = "txtnumeros";
            this.txtnumeros.Size = new System.Drawing.Size(159, 415);
            this.txtnumeros.TabIndex = 13;
            this.txtnumeros.Text = "5511999999999\r\n5511999999998\r\n5511999999997\r\n5511999999996";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "API Key:";
            // 
            // txtapikey
            // 
            this.txtapikey.Location = new System.Drawing.Point(78, 43);
            this.txtapikey.Name = "txtapikey";
            this.txtapikey.Size = new System.Drawing.Size(267, 20);
            this.txtapikey.TabIndex = 11;
            this.txtapikey.Text = "B3CA76C2-07F3-47E6-A2F8-YOWAPIKEY";
            // 
            // txtmin_sleep
            // 
            this.txtmin_sleep.Location = new System.Drawing.Point(384, 43);
            this.txtmin_sleep.Name = "txtmin_sleep";
            this.txtmin_sleep.Size = new System.Drawing.Size(70, 20);
            this.txtmin_sleep.TabIndex = 22;
            this.txtmin_sleep.Text = "30000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(351, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Min:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Max:";
            // 
            // Princ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 740);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtmin_sleep);
            this.Controls.Add(this.txtmax_sleep);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtlog);
            this.Controls.Add(this.btnparar);
            this.Controls.Add(this.btniniciar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtfrases);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtnumeros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtapikey);
            this.Name = "Princ";
            this.Text = "Princ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtmax_sleep;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtlog;
        private System.Windows.Forms.Button btnparar;
        private System.Windows.Forms.Button btniniciar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtfrases;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtnumeros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtapikey;
        private System.Windows.Forms.TextBox txtmin_sleep;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}