using Buya.App.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buya.App.UI.ViewModels.Clientes.Maps
{
    public static class Extensions
    {
        public static ClienteVM ToClienteAddEditVM(this Cliente model)
        {
            return new ClienteVM()
            {
                Id = model.Id_Cliente,
                Nome_Cliente = model.Nome_Cliente,
                Num_BI = model.N_BI,
                DataNascimento = model.Data_Nascimento.Value,
                Sexo = model.Sexo,
                Num_Telefone = model.Telefone,
                //DataCadastro = model.DataCadastro
            };
        }
        public static Cliente ToCliente(this ClienteVM model)
        {
            return new Cliente()
            {
                Id_Cliente = model.Id,
                Nome_Cliente = model.Nome_Cliente,
                N_BI = model.Num_BI,
                Data_Nascimento = model.DataNascimento,
                Sexo = model.Sexo,
                Telefone = model.Num_Telefone
            };
        }
    }
}
