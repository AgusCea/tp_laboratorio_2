using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using Excepciones;

namespace Test_Unitarios
{
    [TestClass]
    public class TestExcepciones
    {
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void AlumnoNacionalidadInvalida_Exception()
        {
            Alumno alumno = new Alumno(1, "Agustin", "Cea", "89999999", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void AlumnoDniInvalido_Exception()
        {
            Alumno alumno = new Alumno(1, "Agustin", "Cea", "89999999,00", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void AlumnoRepetido_Exception()
        {
            Universidad uni = new Universidad();
            Alumno alumno1 = new Alumno(1, "Nombre", "Apellido", "10000001", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno alumno2 = new Alumno(2, "Nombre", "Apellido", "10000002", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno alumno3 = new Alumno(3, "Nombre", "Apellido", "10000001", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            uni += alumno1;
            uni += alumno2;
            uni += alumno3;
        }

        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void SinProfesor_Exception()
        {
            Universidad uni = new Universidad();
            Profesor profesor = new Profesor(1, "Juan", "Lopez", "12224458", EntidadesAbstractas.Persona.ENacionalidad.Argentino);

            uni += profesor;

            uni += Universidad.EClases.Programacion;
            uni += Universidad.EClases.Laboratorio;
            uni += Universidad.EClases.Legislacion;
        }
    }
}
