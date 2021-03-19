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

namespace Parcial1
{
    public partial class Form1 : Form
    {
        List<Estudiante> est = new List<Estudiante>();
        List<Libros> lb = new List<Libros>();
        Boolean l = false;
        int ls = 0;
        Boolean es = false;
        int et = 0;
        public Form1()
        {
            InitializeComponent();
        }

        void escribirEstudiante()
        {
            FileStream stream = new FileStream("estudiantes.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var d in est)
            {
                write.WriteLine(d.Carne);
                write.WriteLine(d.Nombre);
                write.WriteLine(d.Direccion);
            }
            write.Close();
        }

        void leerEstudiante()
        {
            OpenFileDialog op = new OpenFileDialog();
            string fileName = "estudiantes.txt";
            FileStream st = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(st);
            while (reader.Peek() > -1)
            {
                Estudiante d = new Estudiante();
                d.Carne = reader.ReadLine();
                d.Nombre = reader.ReadLine();
                d.Direccion = reader.ReadLine();
                est.Add(d);
            }
            reader.Close();
        }

        void escribirLibro()
        {
            FileStream stream = new FileStream("libros.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var d in lb)
            {
                write.WriteLine(d.Codigo);
                write.WriteLine(d.Titulo);
                write.WriteLine(d.Autor);
                write.WriteLine(d.Año);
            }
            write.Close();
        }

        void leerLibro()
        {
            OpenFileDialog op = new OpenFileDialog();
            string fileName = "libros.txt";
            FileStream st = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(st);
            while (reader.Peek() > -1)
            {
                Libros d = new Libros();
                d.Codigo = reader.ReadLine();
                d.Titulo = reader.ReadLine();
                d.Autor = reader.ReadLine();
                d.Año = reader.ReadLine();
                lb.Add(d);
            }
            reader.Close();
        }

        void repetidosLibros()
        {
            while (l == false && ls < lb.Count)
            {
                if (lb[ls].Codigo.CompareTo(textBox4.Text) == 0)
                {
                    l = true;
                }
                else
                {
                    ls++;
                }
            }
        }

        void repetidosEstudiantes()
        {
            while (es == false && et < est.Count)
            {
                if (est[et].Carne.CompareTo(textBox1.Text) == 0)
                {
                    es = true;
                }
                else
                {
                    et++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Estudiante ed = new Estudiante();
            ed.Carne = textBox1.Text;
            repetidosEstudiantes();
            if (es)
            {
                MessageBox.Show("Estudiante Ya Registrado");
                es = false;
                et = 0;
            }
            else
            {
                ed.Nombre = textBox2.Text;
                ed.Direccion = textBox3.Text;
                est.Add(ed);
                escribirEstudiante();
                et = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Libros lib = new Libros();
            lib.Codigo = textBox4.Text;
            repetidosLibros();
            if (l)
            {
                MessageBox.Show("Libro Ya Registrado");
                l = false;
                ls = 0;
            }
            else
            {
                lib.Titulo = textBox5.Text;
                lib.Autor = textBox6.Text;
                lib.Año = textBox7.Text;
                lb.Add(lib);
                escribirLibro();
                et = 0;
            }
        }
    }
}
