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
        List<Prestamos> ps = new List<Prestamos>();
        List<Datos> dt = new List<Datos>();
        Boolean l = false;
        int ls = 0;
        Boolean es = false;
        int et = 0;
        Boolean p = false;
        int pd = 0;
        Boolean p1 = false;
        int pd1 = 0;
        Boolean p2 = false;
        int pd2 = 0;
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

        void escribirPrestamo()
        {
            FileStream stream = new FileStream("prestamos.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var d in ps)
            {
                write.WriteLine(d.Carne);
                write.WriteLine(d.Codigo);
                write.WriteLine(d.Inicial);
                write.WriteLine(d.Devolucion);
            }
            write.Close();
        }

        void leerPrestamo()
        {
            OpenFileDialog op = new OpenFileDialog();
            string fileName = "prestamos.txt";
            FileStream st = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(st);
            while (reader.Peek() > -1)
            {
                Prestamos d = new Prestamos();
                d.Carne = reader.ReadLine();
                d.Codigo = reader.ReadLine();
                d.Inicial = reader.ReadLine();
                d.Devolucion = reader.ReadLine();
                ps.Add(d);
            }
            reader.Close();
        }

        void escribirPrestamo2()
        {
            FileStream stream = new FileStream("datos.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var d in dt)
            {
                write.WriteLine(d.Nombre);
                write.WriteLine(d.Titulo);
                write.WriteLine(d.Inicial);
                write.WriteLine(d.Devolucion);
            }
            write.Close();
        }

        void leerPrestamo2()
        {
            OpenFileDialog op = new OpenFileDialog();
            string fileName = "datos.txt";
            FileStream st = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(st);
            while (reader.Peek() > -1)
            {
                Datos d = new Datos();
                d.Nombre = reader.ReadLine();
                d.Titulo = reader.ReadLine();
                d.Inicial = reader.ReadLine();
                d.Devolucion = reader.ReadLine();
                dt.Add(d);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
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

        void repetidosPrestamos()
        {
            while (p == false && pd < ps.Count)
            {
                if (ps[pd].Carne.CompareTo(textBox9.Text) == 0)
                {
                    p = true;
                }
                else
                {
                    pd++;
                }
            }
        }

        void repetidosPrestamos2()
        {
            while (p1 == false && pd1 < lb.Count)
            {
                if (lb[pd1].Codigo.CompareTo(textBox9.Text) == 0)
                {
                    p1 = true;
                }
                else
                {
                    pd1++;
                }
            }
        }

        void repetidosPrestamos3()
        {
            while (p2 == false && pd2 < est.Count)
            {
                if (est[pd2].Carne.CompareTo(textBox8.Text) == 0)
                {
                    p2 = true;
                }
                else
                {
                    pd2++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                Estudiante ed = new Estudiante();
                ed.Carne = textBox1.Text;
                repetidosEstudiantes();
                if (es)
                {
                    MessageBox.Show("Estudiante Ya Registrado");
                    textBox1.Clear();
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
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrEmpty(textBox7.Text))
            {
                Libros lib = new Libros();
                lib.Codigo = textBox4.Text;
                repetidosLibros();
                if (l)
                {
                    MessageBox.Show("Libro Ya Registrado");
                    textBox4.Clear();
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
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                }
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            leerEstudiante();
            leerLibro();
            leerPrestamo();
            leerPrestamo2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrEmpty(textBox9.Text))
            {
                Prestamos d = new Prestamos();
                Datos D = new Datos();
                d.Codigo = textBox9.Text;
                repetidosPrestamos2();
                leerLibro();
                if (p1)
                {
                    d.Carne = textBox8.Text;
                    repetidosPrestamos3();
                    leerEstudiante();
                    if (p2)
                    {
                        repetidosPrestamos();
                        if (p)
                        {
                            MessageBox.Show("El libro con el código introducido ya se encuentra prestado");
                            textBox8.Clear();
                            p = false;
                            pd = 0;
                        }
                        else
                        {
                            d.Inicial = dateTimePicker1.Value.ToString();
                            d.Devolucion = dateTimePicker2.Value.ToString();
                            D.Nombre = est[pd2].Nombre;
                            D.Titulo = lb[pd1].Titulo;
                            D.Inicial = dateTimePicker1.Value.ToString();
                            D.Devolucion = dateTimePicker2.Value.ToString();
                            ps.Add(d);
                            escribirPrestamo();
                            dt.Add(D);
                            escribirPrestamo2();
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = dt;
                            dataGridView1.Refresh();
                            pd = 0;
                            textBox8.Clear();
                            textBox9.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El estudiante introducido no se encuentra en la base de datos");
                        textBox8.Clear();
                        p2 = false;
                        pd2 = 0;
                    }
                }
                else
                {
                    MessageBox.Show("El libro introducido no se encuentra en la base de datos");
                    textBox9.Clear();
                    p1 = false;
                    pd1 = 0;
                }
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
        }
    }
}
