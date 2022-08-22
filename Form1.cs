using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejem1
{
    public partial class Form1 : Form
    {
        static private List<Token> lis_toks;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String texto;
            texto = richTextBox1.Text;
            Analizador analiz = new Analizador();
            analiz.Analizador_cadena(texto);

            analiz.generarLista();
            richTextBox2.Text = analiz.getRetorno();


            lis_toks = new List<Token>();
            lis_toks = analiz.getListaTokens();
            
        }
    }
}
