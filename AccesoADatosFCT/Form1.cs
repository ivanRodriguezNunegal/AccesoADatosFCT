using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.DBBOFCT;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GenParametroWU
{
    public partial class Form1 : Form
    {

        #region Metodos

        public Form1()
        {
            InitializeComponent();
            using (BOFCTEntities db = new BOFCTEntities())
            {
                LoadControls(db);
            }
        }

        private void LoadControls(BOFCTEntities db)
        {
        }


        #endregion

        #region Eventos

        private void button1_Click(object sender, EventArgs e)
        {
            using (BOFCTEntities db = new BOFCTEntities())
            {
                List<Usuario> u = Usuario.GetList(db);
                if(u.Count > 0)
                {
                    dataGridView1.DataSource = u;
                }
                
            }
        }




        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            using (BOFCTEntities db = new BOFCTEntities())
            {
                Usuario u = db.Usuario.Create();
                u.Nombre = "User dummy";
                u.FechaCreacion = DateTime.UtcNow;
                u.Login = txtLogin.Text;
                u.Descripcion = "ss";
                u.Activo = true;
                db.Usuario.Add(u);
                db.SaveChanges();
            }
            txtLogin.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (BOFCTEntities db = new BOFCTEntities())
            {
                Usuario u = Usuario.GetUsuarioByID(db, Convert.ToInt32(txtID.Text));
                if (u != null)
                {
                    db.Usuario.Remove(u);
                    db.SaveChanges();
                }
                txtID.Text = "";
            } 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (BOFCTEntities db = new BOFCTEntities())
            {
                Usuario u = Usuario.GetUsuarioByID(db, Convert.ToInt32(txtIDUpdate.Text));
                if (u != null)
                {
                    u.Login = txtLoginUpdate.Text;
                    db.SaveChanges();
                }
            }
            txtIDUpdate.Text = "";
            txtLoginUpdate.Text = "";
        }
    }
}
