using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Archivos;

namespace Test_Unitario
{
    [TestClass]
    public class ArchivoTest
    {
        [TestMethod]
        public void GuardarArchivoTexto_prueba()
        {
            Registros registros = new Registros();
            Pelota pelota = new Pelota("Pirulo", 666, 10, Pelota.EDeporte.Futbol);
            VideoJuego videoJuego = new VideoJuego("Pirulo", 555, 10, "Mario 2021");
            Venta<Pelota> pelotaVendida = new Venta<Pelota>(pelota, 5);
            Venta<VideoJuego> juegoVendido = new Venta<VideoJuego>(videoJuego, 5);
            Texto texto = new Texto();
            bool aux1 = false;
            bool aux2 = false;

            registros.pelotasVendidas.Add(pelotaVendida);
            registros.juegosVendidos.Add(juegoVendido);

            aux1 = texto.Guardar(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Pelotas_vendidas.txt"), registros.pelotasVendidas[0].ToString());
            aux2 = texto.Guardar(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "VideoJuegos_vendidos.txt"), registros.juegosVendidos[0].ToString());

            Assert.IsTrue(aux1 && aux2);
        }

        [TestMethod]
        public void LeerArchivoTexto_prueba()
        {
            Texto texto = new Texto();
            bool aux1 = false;
            bool aux2 = false;
            string auxStr;

            aux1 = texto.Leer(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Pelotas_vendidas.txt"), out auxStr);
            aux2 = texto.Leer(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "VideoJuegos_vendidos.txt"), out auxStr);

            Assert.IsTrue(aux1 && aux2);
        }

        [TestMethod]
        public void GuardarArchivoXml_prueba()
        {
            Registros registros = new Registros();
            bool aux = false;
            Xml<Registros> xml = new Xml<Registros>();

            aux = xml.Guardar(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Registro_ventas.xml"), registros);

            Assert.IsTrue(aux);
        }

        [TestMethod]
        public void LeerArchivoXml_prueba()
        {
            Registros registros = new Registros();
            bool aux = false;
            Xml<Registros> xml = new Xml<Registros>();

            aux = xml.Leer(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Registro_ventas.xml"), out registros);

            Assert.IsTrue(aux);
        }
    }
}
