using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using Entidades;
using static Entidades.Pelota;
using Archivos;
using Excepciones;

namespace WindowsForms
{
    public partial class FormPrincipal : Form
    {
        #region "Enumerados"
        public enum EAccion
        {
            Agregar, Modificar, Eliminar, Guardar, Vender
        }
        #endregion

        #region "Atributos"
        protected SqlDataAdapter da;
        protected DataTable dtPelotas;
        protected DataTable dtJuegos;

        protected Registros registros;
        protected Texto texto;
        protected Xml<Registros> xml;
        #endregion

        #region "Constructores"
        public FormPrincipal()
        {
            InitializeComponent();
            this.registros = new Registros();

            this.ConfigurarDataTable_pelotas();
            this.ConfigurarDataTable_juegos();
            this.ConfigurarGrilla();

            this.StartPosition = FormStartPosition.CenterScreen;
        }
        #endregion

        #region "Manejadores de Eventos"
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            this.InicializarFechaHora();
        }

        private void btnCargarListaPelotas_Click(object sender, EventArgs e)
        {
            if (this.ConfigurarDataAdapter_pelotas())
            {
                try
                {
                    this.da.Fill(this.dtPelotas);
                    this.dgvGrilla.DataSource = this.dtPelotas;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("ERROR AL CONFIGURAR EL DATAADAPTER!!!");
            }
        }

        private void btnCargarListaVideoJuegos_Click(object sender, EventArgs e)
        {
            if (this.ConfigurarDataAdapter_juegos())
            {
                try
                {
                    this.da.Fill(this.dtJuegos);
                    this.dgvGrilla.DataSource = this.dtJuegos;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("ERROR AL CONFIGURAR EL DATAADAPTER!!!");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.ValidarBotonLista(EAccion.Agregar);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.ValidarBotonLista(EAccion.Modificar);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.ValidarBotonLista(EAccion.Eliminar);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.ValidarBotonLista(EAccion.Guardar);
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            this.ValidarBotonLista(EAccion.Vender);
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            xml = new Xml<Registros>();

            try
            {
                if (xml.Guardar(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Registro_ventas.xml"), this.registros))
                {
                    MessageBox.Show("Se actualizo el archivo Registro_ventas.xml");
                }
            }
            catch (ArchivosException ex)
            {
                MessageBox.Show(ex.RazonException());
            }
        }

        private void btnDeserializar_Click(object sender, EventArgs e)
        {
            xml = new Xml<Registros>();

            try
            {
                if (xml.Leer(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Registro_ventas.xml"), out this.registros))
                {
                    MessageBox.Show("Se deserializo correctamente desde archivo Registro_ventas.xml");
                }
                else
                {
                    MessageBox.Show("Elarchivo Registro_ventas.xml no existe.");
                }
            }
            catch (ArchivosException ex)
            {
                MessageBox.Show(ex.RazonException());
            }
        }

        private void btnPelotasVendidas_Click(object sender, EventArgs e)
        {
            texto = new Texto();
            string lectura = default;

            try
            {
                if (texto.Leer(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Pelotas_vendidas.txt"), out lectura))
                {
                    this.richTextBoxVentas.Text = lectura;
                }
                else
                {
                    MessageBox.Show("Elarchivo Pelotas_vendidas.txt no existe.");
                }
            }
            catch (ArchivosException ex)
            {
                MessageBox.Show(ex.RazonException());
            }
        }

        private void btnJuegosVendidos_Click(object sender, EventArgs e)
        {
            texto = new Texto();
            string lectura = default;

            try
            {
                if (texto.Leer(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "VideoJuegos_vendidos.txt"), out lectura))
                {
                    this.richTextBoxVentas.Text = lectura;
                }
                else
                {
                    MessageBox.Show("Elarchivo VideoJuegos_vendidos.txt no existe.");
                }
            }
            catch (ArchivosException ex)
            {
                MessageBox.Show(ex.RazonException());
            }
        }
        #endregion

        #region "Métodos Privados"

        #region DataAdapter
        /// <summary>
        /// Configura el DataAdapter para ejecutar comandos sobre la lista Pelotas en base de datos.
        /// </summary>
        /// <returns></returns>
        private bool ConfigurarDataAdapter_pelotas()
        {
            bool rta = false;

            try
            {
                SqlConnection cn = new SqlConnection(Properties.Settings.Default.ConexionBD);

                this.da = new SqlDataAdapter();

                this.da.SelectCommand = new SqlCommand("SELECT id, deporte, marca, precio, stock FROM PELOTAS", cn);
                this.da.InsertCommand = new SqlCommand("INSERT INTO PELOTAS (deporte, marca, precio, stock) VALUES (@deporte, @marca, @precio, @stock)", cn);
                this.da.UpdateCommand = new SqlCommand("UPDATE PELOTAS SET deporte=@deporte, marca=@marca, precio=@precio, stock=@stock WHERE id=@id", cn);
                this.da.DeleteCommand = new SqlCommand("DELETE FROM PELOTAS WHERE id=@id", cn);

                this.da.InsertCommand.Parameters.Add("@deporte", SqlDbType.VarChar, 50, "deporte");
                this.da.InsertCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
                this.da.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 50, "precio");
                this.da.InsertCommand.Parameters.Add("@stock", SqlDbType.Int, 10, "stock");

                this.da.UpdateCommand.Parameters.Add("@deporte", SqlDbType.VarChar, 50, "deporte");
                this.da.UpdateCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
                this.da.UpdateCommand.Parameters.Add("@precio", SqlDbType.Float, 50, "precio");
                this.da.UpdateCommand.Parameters.Add("@stock", SqlDbType.Int, 10, "stock");
                this.da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                this.da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                rta = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return rta;
        }

        /// <summary>
        /// Configura el DataAdapter para ejecutar comandos sobre la lista VideoJuegos en base de datos.
        /// </summary>
        /// <returns></returns>
        private bool ConfigurarDataAdapter_juegos()
        {
            bool rta = false;

            try
            {
                SqlConnection cn = new SqlConnection(Properties.Settings.Default.ConexionBD);

                this.da = new SqlDataAdapter();

                this.da.SelectCommand = new SqlCommand("SELECT id, nombre, marca, precio, stock FROM VIDEOJUEGOS", cn);
                this.da.InsertCommand = new SqlCommand("INSERT INTO VIDEOJUEGOS (nombre, marca, precio, stock) VALUES (@nombre, @marca, @precio, @stock)", cn);
                this.da.UpdateCommand = new SqlCommand("UPDATE VIDEOJUEGOS SET nombre=@nombre, marca=@marca, precio=@precio, stock=@stock WHERE id=@id", cn);
                this.da.DeleteCommand = new SqlCommand("DELETE FROM VIDEOJUEGOS WHERE id=@id", cn);

                this.da.InsertCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "nombre");
                this.da.InsertCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
                this.da.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 50, "precio");
                this.da.InsertCommand.Parameters.Add("@stock", SqlDbType.Int, 10, "stock");

                this.da.UpdateCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "nombre");
                this.da.UpdateCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
                this.da.UpdateCommand.Parameters.Add("@precio", SqlDbType.Float, 50, "precio");
                this.da.UpdateCommand.Parameters.Add("@stock", SqlDbType.Int, 10, "stock");
                this.da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                this.da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                rta = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return rta;
        }
        #endregion

        #region DataTable
        /// <summary>
        /// Configura una Tabla de Datos para mostrar la informacion de Pelotas.
        /// </summary>
        private void ConfigurarDataTable_pelotas()
        {
            this.dtPelotas = new DataTable("Pelotas");
            this.dtPelotas.Columns.Add("id", typeof(int));
            this.dtPelotas.PrimaryKey = new DataColumn[] { this.dtPelotas.Columns[0] };

            this.dtPelotas.Columns["id"].AutoIncrement = true;
            this.dtPelotas.Columns["id"].AutoIncrementSeed = 1;
            this.dtPelotas.Columns["id"].AutoIncrementStep = 1;
        }

        /// <summary>
        /// Configura una Tabla de Datos para mostrar la informacion de VideoJuegos.
        /// </summary>
        private void ConfigurarDataTable_juegos()
        {
            this.dtJuegos = new DataTable("VideoJuegos");
            this.dtJuegos.Columns.Add("id", typeof(int));
            this.dtJuegos.PrimaryKey = new DataColumn[] { this.dtJuegos.Columns[0] };

            this.dtJuegos.Columns["id"].AutoIncrement = true;
            this.dtJuegos.Columns["id"].AutoIncrementSeed = 1;
            this.dtJuegos.Columns["id"].AutoIncrementStep = 1;
        }
        #endregion

        #region DataGridView
        private void ConfigurarGrilla()
        {
            // Coloco color de fondo para las filas
            this.dgvGrilla.RowsDefaultCellStyle.BackColor = Color.Wheat;

            // Alterno colores
            this.dgvGrilla.AlternatingRowsDefaultCellStyle.BackColor = Color.BurlyWood;

            // Pongo color de fondo a la grilla
            this.dgvGrilla.BackgroundColor = Color.Beige;

            // Defino fuente para el encabezado y alineación del encabezado
            this.dgvGrilla.ColumnHeadersDefaultCellStyle.Font = new Font(dgvGrilla.Font, FontStyle.Bold);
            this.dgvGrilla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Defino el color de las lineas de separación
            this.dgvGrilla.GridColor = Color.HotPink;

            // La grilla será de sólo lectura
            this.dgvGrilla.ReadOnly = false;

            // No permito la multiselección
            this.dgvGrilla.MultiSelect = false;

            // Selecciono toda la fila a la vez
            this.dgvGrilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Hago que las columnas ocupen todo el ancho del 'DataGrid'
            this.dgvGrilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Indico el color de la fila seleccionada
            this.dgvGrilla.RowsDefaultCellStyle.SelectionBackColor = Color.DarkOliveGreen;
            this.dgvGrilla.RowsDefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            // No permito modificar desde la grilla
            this.dgvGrilla.EditMode = DataGridViewEditMode.EditProgrammatically;

            // Saco los encabezados de las filas
            this.dgvGrilla.RowHeadersVisible = false;
        }

        #endregion

        #region "Validar botón"
        /// <summary>
        /// Verifica que halla una lista cargada sobre la cual ejecutar el comando; caso contrario, lo indica
        /// </summary>
        /// <param name="accion"></param>
        void ValidarBotonLista(EAccion accion)
        {
            object auxDataSource = this.dgvGrilla.DataSource;

            if (auxDataSource == this.dtPelotas)
            {
                switch (accion)
                {
                    case EAccion.Agregar:
                        this.AgregarPelotas();
                        break;

                    case EAccion.Modificar:
                        this.ModificarPelotas();
                        break;

                    case EAccion.Eliminar:
                        this.EliminarPelotas();
                        break;

                    case EAccion.Guardar:
                        this.GuardarPelotas();
                        break;

                    case EAccion.Vender:
                        this.VenderPelotas();
                        break;
                }
            }
            else if (auxDataSource == this.dtJuegos)
            {
                switch (accion)
                {
                    case EAccion.Agregar:
                        this.AgregarJuegos();
                        break;

                    case EAccion.Modificar:
                        this.ModificarJuegos();
                        break;

                    case EAccion.Eliminar:
                        this.EliminarJuegos();
                        break;

                    case EAccion.Guardar:
                        this.GuardarJuegos();
                        break;

                    case EAccion.Vender:
                        this.VenderJuegos();
                        break;
                }
            }
            else
            {
                MessageBox.Show("CARGUE UNA LISTA PRIMERO");
            }
        }
        #endregion

        #region "Agregar"
        /// <summary>
        /// Genera e inserta un producto Pelota en el inventario.
        /// </summary>
        private void AgregarPelotas()
        {
            FormPelota frm = new FormPelota();

            frm.StartPosition = FormStartPosition.CenterScreen;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow fila = this.dtPelotas.NewRow();

                fila["deporte"] = frm.Pelota.Deporte;
                fila["marca"] = frm.Pelota.Marca;
                fila["precio"] = frm.Pelota.Precio;
                fila["stock"] = frm.Pelota.Stock;

                this.dtPelotas.Rows.Add(fila);
            }
        }

        /// <summary>
        /// Genera e inserta un producto VideoJuego en el inventario.
        /// </summary>
        private void AgregarJuegos()
        {
            FormVideoJuego frm = new FormVideoJuego();

            frm.StartPosition = FormStartPosition.CenterScreen;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow fila = this.dtJuegos.NewRow();

                fila["nombre"] = frm.VideoJuego.Nombre;
                fila["marca"] = frm.VideoJuego.Marca;
                fila["precio"] = frm.VideoJuego.Precio;
                fila["stock"] = frm.VideoJuego.Stock;

                this.dtJuegos.Rows.Add(fila);
            }
        }
        #endregion

        #region "Modificar"
        /// <summary>
        /// Modifica un producto Pelota del inventario.
        /// </summary>
        private void ModificarPelotas()
        {
            int i = this.dgvGrilla.SelectedRows[0].Index;
            DataRow fila = this.dtPelotas.Rows[i];

            EDeporte deporte = (EDeporte)Enum.Parse(typeof(EDeporte), fila["deporte"].ToString(), true);
            string marca = fila["marca"].ToString();
            float precio = float.Parse(fila["precio"].ToString());
            int stock = int.Parse(fila["stock"].ToString());

            Pelota pelota = new Pelota(marca, precio, stock, deporte);
            FormPelota frm = new FormPelota(pelota);

            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                fila["deporte"] = frm.Pelota.Deporte.ToString();
                fila["marca"] = frm.Pelota.Marca;
                fila["precio"] = frm.Pelota.Precio;
                fila["stock"] = frm.Pelota.Stock;
            }
        }

        /// <summary>
        /// Modifica un producto VideoJuego del inventario.
        /// </summary>
        private void ModificarJuegos()
        {
            int i = this.dgvGrilla.SelectedRows[0].Index;
            DataRow fila = this.dtJuegos.Rows[i];

            string nombre = fila["nombre"].ToString();
            string marca = fila["marca"].ToString();
            float precio = float.Parse(fila["precio"].ToString());
            int stock = int.Parse(fila["stock"].ToString());

            VideoJuego videoJuego = new VideoJuego(marca, precio, stock, nombre);
            FormVideoJuego frm = new FormVideoJuego(videoJuego);

            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                fila["nombre"] = frm.VideoJuego.Nombre;
                fila["marca"] = frm.VideoJuego.Marca;
                fila["precio"] = frm.VideoJuego.Precio;
                fila["stock"] = frm.VideoJuego.Stock;
            }
        }

        #endregion

        #region "Eliminar"
        /// <summary>
        /// Elimina un producto Pelota del inventario.
        /// </summary>
        private void EliminarPelotas()
        {
            int i = this.dgvGrilla.SelectedRows[0].Index;
            DataRow fila = this.dtPelotas.Rows[i];

            EDeporte deporte = (EDeporte)Enum.Parse(typeof(EDeporte), fila["deporte"].ToString(), true);
            string marca = fila["marca"].ToString();
            float precio = float.Parse(fila["precio"].ToString());
            int stock = int.Parse(fila["stock"].ToString());

            Pelota pelota = new Pelota(marca, precio, stock, deporte);

            if (MessageBox.Show(pelota.ToString(), "Eliminar este producto?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                fila.Delete();
            }
        }

        /// <summary>
        /// Elimina un producto VideoJuego del inventario.
        /// </summary>
        private void EliminarJuegos()
        {
            int i = this.dgvGrilla.SelectedRows[0].Index;
            DataRow fila = this.dtJuegos.Rows[i];

            string nombre = fila["nombre"].ToString();
            string marca = fila["marca"].ToString();
            float precio = float.Parse(fila["precio"].ToString());
            int stock = int.Parse(fila["stock"].ToString());

            VideoJuego videoJuego = new VideoJuego(marca, precio, stock, nombre);

            if (MessageBox.Show(videoJuego.ToString(), "Eliminar este producto?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                fila.Delete();
            }
        }
        #endregion

        #region "Guardar"
        /// <summary>
        /// Actualiza la lista de Pelotas en base de datos y sobreescribe el archivo Pelotas_vendidas.txt.
        /// </summary>
        private void GuardarPelotas()
        {
            texto = new Texto();

            try
            {
                this.da.Update(this.dtPelotas);
                if (texto.Guardar(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Pelotas_vendidas.txt"), PelotasVendidasToString()))
                {
                    MessageBox.Show("Se actualizo el archivo Pelotas_vendidas.txt");
                }
                MessageBox.Show("Lista Pelotas Sincronizada!!!");
            }
            catch (ArchivosException ex)
            {
                MessageBox.Show(ex.RazonException());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza la lista de VideoJuegos en base de datos y sobreescribe el archivo VideoJuegos_vendidos.txt.
        /// </summary>
        private void GuardarJuegos()
        {
            texto = new Texto();

            try
            {
                this.da.Update(this.dtJuegos);
                if (texto.Guardar(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "VideoJuegos_vendidos.txt"), JuegosVendidosToString()))
                {
                    MessageBox.Show("Se actualizo el archivo VideoJuegos_vendidos.txt");
                }
                MessageBox.Show("Lista VideoJuegos Sincronizada!!!");
            }
            catch (ArchivosException ex)
            {
                MessageBox.Show(ex.RazonException());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region "Vender"
        /// <summary>
        /// Genera un formulario para vender el producto Pelota.
        /// Si se vende con exito y el stock del producto llega a cero, lo elimina de la lista.
        /// </summary>
        private void VenderPelotas()
        {
            int i = this.dgvGrilla.SelectedRows[0].Index;
            DataRow fila = this.dtPelotas.Rows[i];

            EDeporte deporte = (EDeporte)Enum.Parse(typeof(EDeporte), fila["deporte"].ToString(), true);
            string marca = fila["marca"].ToString();
            float precio = float.Parse(fila["precio"].ToString());
            int stock = int.Parse(fila["stock"].ToString());

            Pelota pelota = new Pelota(marca, precio, stock, deporte);
            FormVenta<Pelota> frm = new FormVenta<Pelota>(pelota);

            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.Producto.Stock == 0)
                {
                    fila.Delete();
                }
                else if (frm.Producto.Stock > 0)
                {
                    fila["stock"] = frm.Producto.Stock;
                }
                this.registros.pelotasVendidas.Add(frm.Venta);
            }
        }

        /// <summary>
        /// Genera un formulario para vender el producto VideoJuego.
        /// Si se vende con exito y el stock del producto llega a cero, lo elimina de la lista.
        /// </summary>
        private void VenderJuegos()
        {
            int i = this.dgvGrilla.SelectedRows[0].Index;
            DataRow fila = this.dtJuegos.Rows[i];

            string nombre = fila["nombre"].ToString();
            string marca = fila["marca"].ToString();
            float precio = float.Parse(fila["precio"].ToString());
            int stock = int.Parse(fila["stock"].ToString());

            VideoJuego videoJuego = new VideoJuego(marca, precio, stock, nombre);
            FormVenta<VideoJuego> frm = new FormVenta<VideoJuego>(videoJuego);

            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.Producto.Stock == 0)
                {
                    fila.Delete();
                }
                else if (frm.Producto.Stock > 0)
                {
                    fila["stock"] = frm.Producto.Stock;
                }
                this.registros.juegosVendidos.Add(frm.Venta);
            }
        }
        #endregion

        #region "Listas de Ventas ToString"
        /// <summary>
        /// Devuelve la informacion de pelotas vendidas
        /// </summary>
        /// <returns></returns>
        private string PelotasVendidasToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Venta<Pelota> item in this.registros.pelotasVendidas)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Devuelve la informacion de juegos vendidos.
        /// </summary>
        /// <returns></returns>
        private string JuegosVendidosToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Venta<VideoJuego> item in this.registros.juegosVendidos)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region "Fecha y Hora"
        /// <summary>
        /// Instancia y corre un hilo secundario para mostrar fecha y hora en tiempo real.
        /// </summary>
        private void InicializarFechaHora()
        {
            Thread thread = new Thread(ActualizarFechaHora);
            thread.Start();
        }

        /// <summary>
        /// Actualiza el label lblFechaHora cada segundo.
        /// </summary>
        private void ActualizarFechaHora()
        {
            while (true)
            {
                if (this.lblFechaHora.InvokeRequired)
                {
                    this.lblFechaHora.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.lblFechaHora.Text = DateTime.Now.ToString();
                    });
                }
                else
                {
                    this.lblFechaHora.Text = DateTime.Now.ToString();
                }

                Thread.Sleep(1000);
            }
        }

        #endregion

        #endregion

        
    }
}
