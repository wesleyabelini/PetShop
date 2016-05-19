namespace PetShop
{
    partial class FormAdmin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdmin));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.buttonCadastroCasa = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.textBoxNomeCasa = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxValor = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonCadastroServico = new System.Windows.Forms.Button();
            this.textBoxDescricaoServico = new System.Windows.Forms.TextBox();
            this.textBoxNomeServico = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonAddFuncao = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxFuncao = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNomeUsuario = new System.Windows.Forms.TextBox();
            this.buttonCadastroFuncionario = new System.Windows.Forms.Button();
            this.textBoxSenhaUsuario = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxLoginUsuario = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(467, 258);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox11);
            this.tabPage1.ImageIndex = 2;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(459, 231);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Casa";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.buttonCadastroCasa);
            this.groupBox11.Controls.Add(this.label28);
            this.groupBox11.Controls.Add(this.textBoxNomeCasa);
            this.groupBox11.Location = new System.Drawing.Point(36, 42);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(386, 147);
            this.groupBox11.TabIndex = 1;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Casa Pet";
            // 
            // buttonCadastroCasa
            // 
            this.buttonCadastroCasa.Location = new System.Drawing.Point(272, 92);
            this.buttonCadastroCasa.Name = "buttonCadastroCasa";
            this.buttonCadastroCasa.Size = new System.Drawing.Size(75, 23);
            this.buttonCadastroCasa.TabIndex = 2;
            this.buttonCadastroCasa.Text = "Cadastrar";
            this.buttonCadastroCasa.UseVisualStyleBackColor = true;
            this.buttonCadastroCasa.Click += new System.EventHandler(this.buttonCadastroCasa_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(29, 41);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(35, 13);
            this.label28.TabIndex = 1;
            this.label28.Text = "Nome";
            // 
            // textBoxNomeCasa
            // 
            this.textBoxNomeCasa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxNomeCasa.Location = new System.Drawing.Point(94, 38);
            this.textBoxNomeCasa.Name = "textBoxNomeCasa";
            this.textBoxNomeCasa.Size = new System.Drawing.Size(253, 20);
            this.textBoxNomeCasa.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox10);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(459, 231);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Serviços";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label3);
            this.groupBox10.Controls.Add(this.textBoxValor);
            this.groupBox10.Controls.Add(this.label14);
            this.groupBox10.Controls.Add(this.label9);
            this.groupBox10.Controls.Add(this.buttonCadastroServico);
            this.groupBox10.Controls.Add(this.textBoxDescricaoServico);
            this.groupBox10.Controls.Add(this.textBoxNomeServico);
            this.groupBox10.Location = new System.Drawing.Point(20, 13);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(418, 205);
            this.groupBox10.TabIndex = 1;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Serviços";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Valor";
            // 
            // textBoxValor
            // 
            this.textBoxValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxValor.Location = new System.Drawing.Point(316, 31);
            this.textBoxValor.Name = "textBoxValor";
            this.textBoxValor.Size = new System.Drawing.Size(94, 20);
            this.textBoxValor.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Descrição";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Serviço";
            // 
            // buttonCadastroServico
            // 
            this.buttonCadastroServico.Location = new System.Drawing.Point(335, 170);
            this.buttonCadastroServico.Name = "buttonCadastroServico";
            this.buttonCadastroServico.Size = new System.Drawing.Size(75, 23);
            this.buttonCadastroServico.TabIndex = 2;
            this.buttonCadastroServico.Text = "Cadastrar";
            this.buttonCadastroServico.UseVisualStyleBackColor = true;
            this.buttonCadastroServico.Click += new System.EventHandler(this.buttonCadastroServico_Click);
            // 
            // textBoxDescricaoServico
            // 
            this.textBoxDescricaoServico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxDescricaoServico.Location = new System.Drawing.Point(81, 76);
            this.textBoxDescricaoServico.Multiline = true;
            this.textBoxDescricaoServico.Name = "textBoxDescricaoServico";
            this.textBoxDescricaoServico.Size = new System.Drawing.Size(329, 79);
            this.textBoxDescricaoServico.TabIndex = 1;
            // 
            // textBoxNomeServico
            // 
            this.textBoxNomeServico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxNomeServico.Location = new System.Drawing.Point(81, 31);
            this.textBoxNomeServico.Name = "textBoxNomeServico";
            this.textBoxNomeServico.Size = new System.Drawing.Size(189, 20);
            this.textBoxNomeServico.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.ImageIndex = 0;
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(459, 231);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Funcionarios";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.buttonAddFuncao);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.comboBoxFuncao);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.textBoxNomeUsuario);
            this.groupBox6.Controls.Add(this.buttonCadastroFuncionario);
            this.groupBox6.Controls.Add(this.textBoxSenhaUsuario);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.textBoxLoginUsuario);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Location = new System.Drawing.Point(68, 21);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(323, 189);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Cadastro Funcionário";
            // 
            // buttonAddFuncao
            // 
            this.buttonAddFuncao.Location = new System.Drawing.Point(267, 29);
            this.buttonAddFuncao.Name = "buttonAddFuncao";
            this.buttonAddFuncao.Size = new System.Drawing.Size(30, 23);
            this.buttonAddFuncao.TabIndex = 9;
            this.buttonAddFuncao.Text = "+";
            this.buttonAddFuncao.UseVisualStyleBackColor = true;
            this.buttonAddFuncao.Click += new System.EventHandler(this.buttonAddFuncao_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Função";
            // 
            // comboBoxFuncao
            // 
            this.comboBoxFuncao.FormattingEnabled = true;
            this.comboBoxFuncao.Location = new System.Drawing.Point(88, 29);
            this.comboBoxFuncao.Name = "comboBoxFuncao";
            this.comboBoxFuncao.Size = new System.Drawing.Size(173, 21);
            this.comboBoxFuncao.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nome";
            // 
            // textBoxNomeUsuario
            // 
            this.textBoxNomeUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxNomeUsuario.Location = new System.Drawing.Point(88, 56);
            this.textBoxNomeUsuario.Name = "textBoxNomeUsuario";
            this.textBoxNomeUsuario.Size = new System.Drawing.Size(209, 20);
            this.textBoxNomeUsuario.TabIndex = 5;
            // 
            // buttonCadastroFuncionario
            // 
            this.buttonCadastroFuncionario.Location = new System.Drawing.Point(222, 144);
            this.buttonCadastroFuncionario.Name = "buttonCadastroFuncionario";
            this.buttonCadastroFuncionario.Size = new System.Drawing.Size(75, 23);
            this.buttonCadastroFuncionario.TabIndex = 4;
            this.buttonCadastroFuncionario.Text = "Cadastrar";
            this.buttonCadastroFuncionario.UseVisualStyleBackColor = true;
            this.buttonCadastroFuncionario.Click += new System.EventHandler(this.buttonCadastroFuncionario_Click);
            // 
            // textBoxSenhaUsuario
            // 
            this.textBoxSenhaUsuario.Location = new System.Drawing.Point(88, 108);
            this.textBoxSenhaUsuario.Name = "textBoxSenhaUsuario";
            this.textBoxSenhaUsuario.PasswordChar = '*';
            this.textBoxSenhaUsuario.Size = new System.Drawing.Size(209, 20);
            this.textBoxSenhaUsuario.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(25, 111);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 13);
            this.label18.TabIndex = 2;
            this.label18.Text = "Senha";
            // 
            // textBoxLoginUsuario
            // 
            this.textBoxLoginUsuario.Location = new System.Drawing.Point(88, 82);
            this.textBoxLoginUsuario.Name = "textBoxLoginUsuario";
            this.textBoxLoginUsuario.Size = new System.Drawing.Size(209, 20);
            this.textBoxLoginUsuario.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(25, 85);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(33, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Login";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Another World (3).ico");
            this.imageList1.Images.SetKeyName(1, "Dog (9).ico");
            this.imageList1.Images.SetKeyName(2, "Home (3).ico");
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 279);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAdmin";
            this.Text = "Administrador";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button buttonCadastroCasa;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox textBoxNomeCasa;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonCadastroServico;
        private System.Windows.Forms.TextBox textBoxDescricaoServico;
        private System.Windows.Forms.TextBox textBoxNomeServico;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxFuncao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNomeUsuario;
        private System.Windows.Forms.Button buttonCadastroFuncionario;
        private System.Windows.Forms.TextBox textBoxSenhaUsuario;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxLoginUsuario;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxValor;
        private System.Windows.Forms.Button buttonAddFuncao;
    }
}