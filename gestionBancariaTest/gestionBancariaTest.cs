using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using gestionBancariaApp;

namespace gestionBancariaTest
{
    [TestClass]
    public class gestionBancariaTest
    {
        [TestMethod]

        public void validarMetodoIngreso()
        {
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double ingreso = 500;
            double saldoActual = 0;
            double saldoEsperado = 1500;

            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            // Método a probar
            cuenta.realizarIngreso(ingreso);
            // Afirmación de la prueba (valor esperado Vs. Valor obtenido)
            saldoActual = cuenta.obtenerSaldo();

            Assert.AreEqual(saldoEsperado, saldoActual, 0.001, "El saldo de la cuenta no es correcto");
        }


        [TestMethod]
        public void validarMetodoReintegro()
        {
            // Preparación del caso de prueba
            double saldoInicial = 1000;
            double reintegro = 500;
            double saldoEsperado = 500;

            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            // Método a probar
            cuenta.realizarReintegro(reintegro);

            // Afirmación de la prueba
            double saldoActual = cuenta.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, saldoActual, 0.001, "El saldo de la cuenta no es correcto");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void validarExcepcionIngresoNegativo()
        {
            // Preparación del caso de prueba
            double saldoInicial = 1000;
            double ingreso = -500;

            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            // debe lanzar ArgumentOutOfRangeException
            cuenta.realizarIngreso(ingreso);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void validarExcepcionReintegroNegativo()
        {
            // Preparación del caso de prueba
            double saldoInicial = 1000;
            double reintegro = -300;

            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            // debe lanzar ArgumentOutOfRangeException
            cuenta.realizarReintegro(reintegro);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void validarExcepcionReintegroSaldoInsuficiente()
        {
            // Preparación del caso de prueba
            double saldoInicial = 1000;
            double reintegro = 2000;

            gestionBancaria cuenta = new gestionBancaria(saldoInicial);

            // debe lanzar ArgumentOutOfRangeException
            cuenta.realizarReintegro(reintegro);
        }
    }
}
