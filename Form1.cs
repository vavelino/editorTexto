using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EditorText
{
    public partial class Form1 : Form
    {
        StringReader leitura = null;
        
        public Form1()
        {
            InitializeComponent();
            // this.saveFileDialog1.Filter = "(*.TXT)|*.TXT";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            Novo();
        }
        private void Novo()
        {
            richTextBox1.Clear();
            richTextBox1.Focus();
        }
        private void Salvar()
        {
            try
            {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);

                    StreamWriter cfb_streamwriter = new StreamWriter(arquivo);
                    cfb_streamwriter.Flush();  // Limpa o buffer 
                    cfb_streamwriter.BaseStream.Seek(0, SeekOrigin.Begin); // Apartir de onde começar
                    cfb_streamwriter.Write(this.richTextBox1.Text);   // O que ele vai escrever
                    cfb_streamwriter.Flush(); // Atualiza o buffer
                    cfb_streamwriter.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de gravação do arquivo" + ex.Message, "Erro ao gravar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salvar();
        }
        private void Abrir()
        {
            this.openFileDialog1.Multiselect = false; // Para não selecionar multiplos arquivos
            openFileDialog1.Title = "Abrir Arquivo";
            openFileDialog1.InitialDirectory = @"D:\OneDrive\Develop\CSharp\EditorText\salvos";
            openFileDialog1.Filter = "(*.txt)|*.txt";
            //   if (this.openFileDialog1.ShowDialog() == DialogResult.OK)   ou
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader cfb_stramreader = new StreamReader(arquivo);
                    cfb_stramreader.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.richTextBox1.Text = "";

                    string linha = cfb_stramreader.ReadLine();
                    while (linha != null)
                    {
                        this.richTextBox1.Text += linha + "\n";
                        linha = cfb_stramreader.ReadLine();
                    }
                    cfb_stramreader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de leitura do arquivo" + ex.Message, "Erro ao ler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void btn_abrir_Click(object sender, EventArgs e)
        {
            Abrir();
        }
        private void Copiar()
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }
        private void Colar()
        {
            richTextBox1.Paste();
        }

        private void btn_copiar_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void btn_colar_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void Negrito()
        {
            int isBold, isItalic, isUnderline;

            isBold = richTextBox1.SelectionFont.Bold ? 0 : 1;
            isItalic = richTextBox1.SelectionFont.Italic ? 2 : 0;
            isUnderline = richTextBox1.SelectionFont.Underline ? 4 : 0;

            richTextBox1.SelectionFont = new Font(richTextBox1.Font.Name, richTextBox1.Font.Size, FontStyle.Regular | FontStyle.Regular + isBold | FontStyle.Regular + isItalic | FontStyle.Regular + isUnderline);
        }
        private void Italico()
        {
            int isBold, isItalic, isUnderline;

            isBold = richTextBox1.SelectionFont.Bold ? 1 : 0;
            isItalic = richTextBox1.SelectionFont.Italic ? 0 : 2;
            isUnderline = richTextBox1.SelectionFont.Underline ? 4 : 0;

            richTextBox1.SelectionFont = new Font(richTextBox1.Font.Name, richTextBox1.Font.Size, FontStyle.Regular | FontStyle.Regular + isBold | FontStyle.Regular + isItalic | FontStyle.Regular + isUnderline);
        }

        private void Sublinhado()
        {
            string nome_da_fonte;
            float tamanho_da_fonte;

            int isBold, isItalic, isUnderline;
            //------ Atribuições
            tamanho_da_fonte = 0;
            nome_da_fonte = null;

            isBold = richTextBox1.SelectionFont.Bold ? 1 : 0;
            isItalic = richTextBox1.SelectionFont.Italic ? 2 : 0;
            isUnderline = richTextBox1.SelectionFont.Underline ? 0 : 4;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;

            richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular | FontStyle.Regular + isBold | FontStyle.Regular + isItalic | FontStyle.Regular + isUnderline);
        }

        private void btn_negrito_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void btn_italico_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void btn_sublinhado_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void itálicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void sublinhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void alinharEsquerda()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }
        private void alinharDireita()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }
        private void alinharCentro()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void btn_centro_Click(object sender, EventArgs e)
        {
            alinharCentro();
        }

        private void btn_direita_Click(object sender, EventArgs e)
        {
            alinharDireita();
        }

        private void btn_esquerda_Click(object sender, EventArgs e)
        {
            alinharEsquerda();
        }

        private void centralizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharCentro();
        }

        private void esquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharEsquerda();
        }

        private void direitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharDireita();
        }
        private void imprimir()
        {
            printDialog1.Document = printDocument1;
            string texto = this.richTextBox1.Text;
            leitura = new StringReader(texto);
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linhasPagina = 0;
            float PosY = 0;
            int count = 0;
            float margemEsquerda = e.MarginBounds.Left - 50;
            float margemSuperior = e.MarginBounds.Top - 50;
            if (margemEsquerda < 5)
            {
                margemEsquerda = 20;
            }
            if (margemSuperior < 5)
            {
                margemSuperior = 20;
            }
            string linha = null;
            Font fonte = this.richTextBox1.Font;
            SolidBrush pincel = new SolidBrush(Color.Black);
            linhasPagina = e.MarginBounds.Height / fonte.GetHeight(e.Graphics);     // conta pra saber linhas por pagina baseando pelas margens
            linha = leitura.ReadLine();
            while (count < linhasPagina)
            {
                PosY = (margemSuperior + (count * fonte.GetHeight(e.Graphics)));
                e.Graphics.DrawString(linha, fonte, pincel, margemEsquerda, PosY, new StringFormat());
                count++;
                linha = leitura.ReadLine();
            }
            e.HasMorePages = (linha != null);// Vai imprimir outra pagina
            pincel.Dispose();
           

        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imprimir();
        }
    }
}
