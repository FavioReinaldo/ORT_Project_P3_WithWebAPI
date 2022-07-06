using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using DataAccess;

namespace ObligatorioP3.Models
{
    public class ViewModelPlanta
    {

        
        public ViewModelPlanta()
        {
            RepositorioTipo repositorio = new RepositorioTipo(new Connection());
            List<Tipo> Tipos = new List<Tipo>();
            Tipos = (List<Tipo>)repositorio.Get();


        }
    }
}
