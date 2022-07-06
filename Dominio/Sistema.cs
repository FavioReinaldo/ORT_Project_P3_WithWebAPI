using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class Sistema
    {

        #region Listas

        private List<Compra> compras = new List<Compra>();
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Planta> plantas = new List<Planta>();
        private List<Tipo> tipos = new List<Tipo>();
        #endregion

        #region Atributos Sistema        
        public List<Compra> Compras
        {
            get { return compras; }
        }
        public List<Tipo> Tipos
        {
            get { return tipos; }
        }
        public List<Planta> Plantas
        {
            get { return plantas; }
        }
        public List<Usuario> Usuarios
        {
            get { return usuarios; }
        }
        #endregion

        #region Singleton
        private static Sistema instancia;

        public static Sistema Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Sistema();
                }
                return instancia;
            }
        }
        #endregion 

        #region Método Constructor de Sistema
        public Sistema() //Metodo constructor de Object
        {
            PreCargarDatosUsuarios();
        }
        #endregion

        #region Método PreCargarDatosUsuarios
        //*************** CARGA DE DATOS DE USUARIOS HARCODEADOS ***************        
        private void PreCargarDatosUsuarios()
        {
            this.usuarios.Add(new Usuario("Usuario1@mail.com", "Usuario1"));
            this.usuarios.Add(new Usuario("Usuario2@mail.com", "Usuario2"));
            this.usuarios.Add(new Usuario("Usuario3@mail.com", "Usuario3"));

        }
        #endregion

        /*
        #region Metodo ValidarTipo
        //*************** METODO VALIDAR TIPO ***************
        public bool ValidarTipo(List<Tipo> miTipo, string Nombre)
        {
            bool resultado = true;

            if (miTipo != null)
            {
                int i = 0;
                while (i < miTipo.Count && resultado == true)
                {

                    if (Nombre.ToUpper().Equals(miTipo[i].Nombre.ToUpper()))
                    {
                        resultado = false;
                    }
                    i++;

                }
            }
            return resultado;
        }
        #endregion
        */


        #region Metodo ValidarAlfabeticoTipo
        //*************** METODO VALIDAR TIPO ***************
        //Este metodo valida que el dato ingresado sea solo alfabetico
        public bool ValidarAlfabeticoTipo(Tipo unTipo)
        {
            bool alfabetico = Regex.IsMatch(unTipo.Nombre, @"^[a-zA-Z]+$"); //No acepta tilde, pero tampoco numeros
            return alfabetico;
        }
        #endregion



        #region Método para Login: ValidarLogIn

        /*  Este metodo valida si los datos de usuario y contraseña corresponden con un usuario y devuelve: False si no se econtro usuario. True si el usuario valido*/
        public bool ValidarLogIn(string miMail, string miPassword)
        {
            bool resultado = false;
            int i = 0;
            while (i < usuarios.Count && resultado == false)
            {

                if (usuarios[i].Mail.ToUpper().Equals(miMail.ToUpper()) && usuarios[i].Password.Equals(miPassword))
                {
                    resultado = true;
                }
                i++;
            }
            return resultado;
        }

        #endregion

        #region Método Listar Plantas
        //*************** METODO PARA ARMAR UNA LISTA DE PLANTAS ***************
        public List<Planta> ListaDePlanta()
        {
            List<Planta> misPlantas = new List<Planta>();

            //foreach (Planta miPlanta in plantas)
            //{
            //    //
            //}
            return misPlantas;
        }
        #endregion

        #region Método Buscar Plantas segun Ambiente
        //*************** METODO PARA BUSCAR PLANTAS SEGUN UN AMBIENTE  ***************

        public List<Planta> BuscarPlantaPorAmbiente(string miAmbiente)
        {

            List<Planta> misPlantasBuscadas = new List<Planta>();
            bool existe = false;
            if (miAmbiente != "")
            {
                foreach (Planta miPlanta in plantas)
                {
                    /*for (int i = 0; i < miPlanta.Ambiente.Count; i++)
                    {

                        if (miPlanta.Ambiente[i] == miAmbiente)
                        {
                            existe = true;
                        }
                    }*/
                    if (existe)
                    {
                        misPlantasBuscadas.Add(miPlanta);
                    }
                }
            }
            return misPlantasBuscadas;
        }

        #endregion  

        #region Método Buscar Plantas mas bajas que X centimetros
        //*************** METODO PARA BUSCAR PLANTAS MAS BAJAS QUE X CENTIMETROS  ***************

        public List<Planta> BuscarPlantaMasBajasQueXCentimetros(double miAlturaMaxima)
        {

            List<Planta> misPlantasBuscadas = new List<Planta>();

            if (miAlturaMaxima > 0)
            {
                foreach (Planta miPlanta in plantas)
                {
                    if (miPlanta.AlturaMaxima < miAlturaMaxima)
                    {
                        misPlantasBuscadas.Add(miPlanta);
                    }
                }
            }
            return misPlantasBuscadas;
        }

        #endregion

        #region Método Buscar Plantas de X centimetros o mas
        //*************** METODO PARA BUSCAR PLANTAS DE X CENTIMETROS O MAS  ***************

        public List<Planta> BuscarPlantaDeXCentimetrosOMas(double miAlturaMaxima)
        {

            List<Planta> misPlantasBuscadas = new List<Planta>();

            if (miAlturaMaxima > 0)
            {
                foreach (Planta miPlanta in plantas)
                {
                    if (miPlanta.AlturaMaxima >= miAlturaMaxima)
                    {
                        misPlantasBuscadas.Add(miPlanta);
                    }
                }
            }
            return misPlantasBuscadas;
        }

        #endregion

        #region Metodo ExisteTipo
        public bool ExisteTipo(string nombre)
        {
            bool tipoEliminado = false;
            Tipo unTipo = BuscarTipo(nombre);
            if (unTipo != null)
            {
                tipoEliminado = true;
            }
            return tipoEliminado;
        }
        #endregion               

        #region Metodo Eliminar Tipo
        public bool EliminarTipo(Tipo tipo)
        {
            bool eliminadoTipo = true;
            int i = 0;

            while (eliminadoTipo && i < plantas.Count)
            {
                if (plantas[i].NombreTipo == tipo.Nombre)
                {
                    eliminadoTipo = false;
                }

                i++;
            }
            return eliminadoTipo;

        }
        #endregion

        #region Metodo Alta Planta
        public bool AltaPlanta(Planta planta)
        {
            bool altaPlanta = false;
            if (planta != null)
            {
                plantas.Add(planta);
                altaPlanta = true;
            }
            return altaPlanta;
        }
        #endregion

        #region Metodo Buscar Planta Por Nombre
        public Planta BuscarPlantaPorNombre(string nombre)
        {
            int i = 0;
            Planta unaPlanta = null;
            while (unaPlanta == null && i < plantas.Count)
            {
                if (plantas[i].NombreCientifico == nombre)
                {
                    unaPlanta = plantas[i];
                }
                i++;
            }
            return unaPlanta;
        }
        #endregion

        #region Metodo Buscra Planta Por Tipo
        public Planta BuscarPlantaPorTipo(string tipo)
        {
            int i = 0;
            Planta unaPlanta = null;
            while (unaPlanta == null && i < plantas.Count)
            {


                if (plantas[i].NombreTipo.Equals(tipo))
                {
                    unaPlanta = plantas[i];
                }
                i++;
            }
            return unaPlanta;
        }
        #endregion

        #region Metodo Tipos
        //Muestra listado de todos los tipos
        public List<Tipo> ListaTipos()
        {
            List<Tipo> aux = new List<Tipo>();
            foreach (Tipo unT in Tipos)
            {
                aux.Add(unT);
            }
            return aux;
        }
        #endregion

        #region Metodo Agregar Tipo
        //Se agrega un objeto Tipo si se cumple con las validaciones del método
        public bool AgregarTipo(Tipo miTipo)
        {
            bool exito = false;
            if (miTipo.ValidarTipo(miTipo.Nombre, miTipo.Descripcion))
            {
                Tipo unT = new Tipo(miTipo.Nombre, miTipo.Descripcion);
                tipos.Add(unT);
                exito = true;
            }
            return exito;
        }

        #endregion

        #region Precargas
        public void Precarga()
        {
            Tipo unTipo;
            unTipo = new Tipo("jorgeRibera@hotmail.com", "jorgeRibera01");
            AgregarTipo(unTipo);
            unTipo = new Tipo("SaulPerez@gmail.com", "saulPerez02");
            AgregarTipo(unTipo);
            unTipo = new Tipo("SamuelDeLuque@gmail.com", "Samuel15");
            AgregarTipo(unTipo);


        }
        #endregion

        #region Metodo Buscar Tipo
        //Busca si existe un objeto Tipo según el nombre del mismo y lo devuelve
        public Tipo BuscarTipo(string nombre)
        {
            Tipo unT = null;
            int i = 0;
            while (unT == null && i < tipos.Count)
            {
                if (tipos[i].Nombre == nombre)
                {
                    unT = tipos[i];
                }
                i++;
            }
            return unT;
        }
        #endregion


        /*
        IRepositorio<Usuario> repositorioUsuario = new RepositorioUsuario(new Connection());

        
        #region Método Cargar datos de usuarios en la lista
        //*************** METODO PARA ARMAR UNA LISTA DE PLANTAS ***************
        private List<Usuario> CargarDatosListaUsuarios()
        {
            List<Usuario> misUsuarios = new List<Usuario>();
            
            foreach (Usuario miUsuario in usuarios)
            {
                repositorioUsuario.Get();
            }
            return misPlantas;
        }
        #endregion
        */

        public bool ValidarDescripcion(Tipo miTipo)
        {
            return miTipo.ValidarDescripcion(miTipo.Descripcion);
        }

    }
}
