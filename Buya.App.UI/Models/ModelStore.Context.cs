﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Buya.App.UI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EstadiaHotBuyaEntities : DbContext
    {
        public EstadiaHotBuyaEntities()
            : base("name=EstadiaHotBuyaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Acesso> Acesso { get; set; }
        public virtual DbSet<AcessoTipo> AcessoTipo { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Estado_Quarto> Estado_Quarto { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<Hospedagem> Hospedagem { get; set; }
        public virtual DbSet<Pagamento> Pagamento { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<Quarto> Quarto { get; set; }
        public virtual DbSet<Quarto_Tipo> Quarto_Tipo { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Servico_Quarto> Servico_Quarto { get; set; }
    
        public virtual int SP_AcessoAlterarNomeSenha(Nullable<int> cod_Acesso, string nome_Usuario, string senha_Usuario)
        {
            var cod_AcessoParameter = cod_Acesso.HasValue ?
                new ObjectParameter("Cod_Acesso", cod_Acesso) :
                new ObjectParameter("Cod_Acesso", typeof(int));
    
            var nome_UsuarioParameter = nome_Usuario != null ?
                new ObjectParameter("Nome_Usuario", nome_Usuario) :
                new ObjectParameter("Nome_Usuario", typeof(string));
    
            var senha_UsuarioParameter = senha_Usuario != null ?
                new ObjectParameter("Senha_Usuario", senha_Usuario) :
                new ObjectParameter("Senha_Usuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_AcessoAlterarNomeSenha", cod_AcessoParameter, nome_UsuarioParameter, senha_UsuarioParameter);
        }
    
        public virtual int SP_AcessoLogin(string nome_Usuario, string senha_Usuario)
        {
            var nome_UsuarioParameter = nome_Usuario != null ?
                new ObjectParameter("Nome_Usuario", nome_Usuario) :
                new ObjectParameter("Nome_Usuario", typeof(string));
    
            var senha_UsuarioParameter = senha_Usuario != null ?
                new ObjectParameter("Senha_Usuario", senha_Usuario) :
                new ObjectParameter("Senha_Usuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_AcessoLogin", nome_UsuarioParameter, senha_UsuarioParameter);
        }
    
        public virtual ObjectResult<string> SP_ClienteAddEdit(Nullable<int> id, string nome_Cliente, Nullable<bool> sexo, string n_BI, Nullable<System.DateTime> data_Nascimento, string telefone, string email, string senha)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nome_ClienteParameter = nome_Cliente != null ?
                new ObjectParameter("Nome_Cliente", nome_Cliente) :
                new ObjectParameter("Nome_Cliente", typeof(string));
    
            var sexoParameter = sexo.HasValue ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(bool));
    
            var n_BIParameter = n_BI != null ?
                new ObjectParameter("N_BI", n_BI) :
                new ObjectParameter("N_BI", typeof(string));
    
            var data_NascimentoParameter = data_Nascimento.HasValue ?
                new ObjectParameter("Data_Nascimento", data_Nascimento) :
                new ObjectParameter("Data_Nascimento", typeof(System.DateTime));
    
            var telefoneParameter = telefone != null ?
                new ObjectParameter("Telefone", telefone) :
                new ObjectParameter("Telefone", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var senhaParameter = senha != null ?
                new ObjectParameter("Senha", senha) :
                new ObjectParameter("Senha", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_ClienteAddEdit", idParameter, nome_ClienteParameter, sexoParameter, n_BIParameter, data_NascimentoParameter, telefoneParameter, emailParameter, senhaParameter);
        }
    
        public virtual ObjectResult<string> SP_ClienteAlterar(Nullable<int> id_Cliente, string nome_Cliente, Nullable<bool> sexo, string n_BI, Nullable<System.DateTime> data_Nascimento, string telefone)
        {
            var id_ClienteParameter = id_Cliente.HasValue ?
                new ObjectParameter("Id_Cliente", id_Cliente) :
                new ObjectParameter("Id_Cliente", typeof(int));
    
            var nome_ClienteParameter = nome_Cliente != null ?
                new ObjectParameter("Nome_Cliente", nome_Cliente) :
                new ObjectParameter("Nome_Cliente", typeof(string));
    
            var sexoParameter = sexo.HasValue ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(bool));
    
            var n_BIParameter = n_BI != null ?
                new ObjectParameter("N_BI", n_BI) :
                new ObjectParameter("N_BI", typeof(string));
    
            var data_NascimentoParameter = data_Nascimento.HasValue ?
                new ObjectParameter("Data_Nascimento", data_Nascimento) :
                new ObjectParameter("Data_Nascimento", typeof(System.DateTime));
    
            var telefoneParameter = telefone != null ?
                new ObjectParameter("Telefone", telefone) :
                new ObjectParameter("Telefone", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_ClienteAlterar", id_ClienteParameter, nome_ClienteParameter, sexoParameter, n_BIParameter, data_NascimentoParameter, telefoneParameter);
        }
    
        public virtual ObjectResult<string> SP_ClienteInserir(string nome_Cliente, Nullable<bool> sexo, string n_BI, Nullable<System.DateTime> data_Nascimento, string telefone)
        {
            var nome_ClienteParameter = nome_Cliente != null ?
                new ObjectParameter("Nome_Cliente", nome_Cliente) :
                new ObjectParameter("Nome_Cliente", typeof(string));
    
            var sexoParameter = sexo.HasValue ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(bool));
    
            var n_BIParameter = n_BI != null ?
                new ObjectParameter("N_BI", n_BI) :
                new ObjectParameter("N_BI", typeof(string));
    
            var data_NascimentoParameter = data_Nascimento.HasValue ?
                new ObjectParameter("Data_Nascimento", data_Nascimento) :
                new ObjectParameter("Data_Nascimento", typeof(System.DateTime));
    
            var telefoneParameter = telefone != null ?
                new ObjectParameter("Telefone", telefone) :
                new ObjectParameter("Telefone", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_ClienteInserir", nome_ClienteParameter, sexoParameter, n_BIParameter, data_NascimentoParameter, telefoneParameter);
        }
    
        public virtual ObjectResult<SP_ClienteLocalizar_Result> SP_ClienteLocalizar(string nome_Cliente)
        {
            var nome_ClienteParameter = nome_Cliente != null ?
                new ObjectParameter("Nome_Cliente", nome_Cliente) :
                new ObjectParameter("Nome_Cliente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ClienteLocalizar_Result>("SP_ClienteLocalizar", nome_ClienteParameter);
        }
    
        public virtual ObjectResult<string> SP_FuncionarioAddEdit(Nullable<int> id, string nome_Funcionario, Nullable<bool> sexo, string n_BI, Nullable<System.DateTime> data_Nascimento, string email, string senha, Nullable<int> acessoTipoId)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nome_FuncionarioParameter = nome_Funcionario != null ?
                new ObjectParameter("Nome_Funcionario", nome_Funcionario) :
                new ObjectParameter("Nome_Funcionario", typeof(string));
    
            var sexoParameter = sexo.HasValue ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(bool));
    
            var n_BIParameter = n_BI != null ?
                new ObjectParameter("N_BI", n_BI) :
                new ObjectParameter("N_BI", typeof(string));
    
            var data_NascimentoParameter = data_Nascimento.HasValue ?
                new ObjectParameter("Data_Nascimento", data_Nascimento) :
                new ObjectParameter("Data_Nascimento", typeof(System.DateTime));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var senhaParameter = senha != null ?
                new ObjectParameter("Senha", senha) :
                new ObjectParameter("Senha", typeof(string));
    
            var acessoTipoIdParameter = acessoTipoId.HasValue ?
                new ObjectParameter("AcessoTipoId", acessoTipoId) :
                new ObjectParameter("AcessoTipoId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_FuncionarioAddEdit", idParameter, nome_FuncionarioParameter, sexoParameter, n_BIParameter, data_NascimentoParameter, emailParameter, senhaParameter, acessoTipoIdParameter);
        }
    
        public virtual ObjectResult<string> SP_HospedagemCheckOut(Nullable<int> id_Hospedagem, Nullable<int> id_Funcionario, Nullable<decimal> total_Pago)
        {
            var id_HospedagemParameter = id_Hospedagem.HasValue ?
                new ObjectParameter("Id_Hospedagem", id_Hospedagem) :
                new ObjectParameter("Id_Hospedagem", typeof(int));
    
            var id_FuncionarioParameter = id_Funcionario.HasValue ?
                new ObjectParameter("Id_Funcionario", id_Funcionario) :
                new ObjectParameter("Id_Funcionario", typeof(int));
    
            var total_PagoParameter = total_Pago.HasValue ?
                new ObjectParameter("Total_Pago", total_Pago) :
                new ObjectParameter("Total_Pago", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_HospedagemCheckOut", id_HospedagemParameter, id_FuncionarioParameter, total_PagoParameter);
        }
    
        public virtual ObjectResult<string> SP_HospedagemInserir(Nullable<int> id_Reserva, Nullable<int> acesso_ID, Nullable<System.DateTime> data_CheckIn, Nullable<System.DateTime> data_CheckOut)
        {
            var id_ReservaParameter = id_Reserva.HasValue ?
                new ObjectParameter("Id_Reserva", id_Reserva) :
                new ObjectParameter("Id_Reserva", typeof(int));
    
            var acesso_IDParameter = acesso_ID.HasValue ?
                new ObjectParameter("Acesso_ID", acesso_ID) :
                new ObjectParameter("Acesso_ID", typeof(int));
    
            var data_CheckInParameter = data_CheckIn.HasValue ?
                new ObjectParameter("Data_CheckIn", data_CheckIn) :
                new ObjectParameter("Data_CheckIn", typeof(System.DateTime));
    
            var data_CheckOutParameter = data_CheckOut.HasValue ?
                new ObjectParameter("Data_CheckOut", data_CheckOut) :
                new ObjectParameter("Data_CheckOut", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_HospedagemInserir", id_ReservaParameter, acesso_IDParameter, data_CheckInParameter, data_CheckOutParameter);
        }
    
        public virtual ObjectResult<SP_LocalizarQuartoTipoAndarEstado_Result> SP_LocalizarQuartoTipoAndarEstado(Nullable<int> iD_Pesquisa)
        {
            var iD_PesquisaParameter = iD_Pesquisa.HasValue ?
                new ObjectParameter("ID_Pesquisa", iD_Pesquisa) :
                new ObjectParameter("ID_Pesquisa", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_LocalizarQuartoTipoAndarEstado_Result>("SP_LocalizarQuartoTipoAndarEstado", iD_PesquisaParameter);
        }
    
        public virtual ObjectResult<string> SP_PedidosAlterar(Nullable<int> id_Pedido, Nullable<int> id_Servico, Nullable<int> id_Hospedagem)
        {
            var id_PedidoParameter = id_Pedido.HasValue ?
                new ObjectParameter("Id_Pedido", id_Pedido) :
                new ObjectParameter("Id_Pedido", typeof(int));
    
            var id_ServicoParameter = id_Servico.HasValue ?
                new ObjectParameter("Id_Servico", id_Servico) :
                new ObjectParameter("Id_Servico", typeof(int));
    
            var id_HospedagemParameter = id_Hospedagem.HasValue ?
                new ObjectParameter("Id_Hospedagem", id_Hospedagem) :
                new ObjectParameter("Id_Hospedagem", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_PedidosAlterar", id_PedidoParameter, id_ServicoParameter, id_HospedagemParameter);
        }
    
        public virtual ObjectResult<string> SP_PedidosInserir(Nullable<int> id_Servico, Nullable<int> id_Hospedagem)
        {
            var id_ServicoParameter = id_Servico.HasValue ?
                new ObjectParameter("Id_Servico", id_Servico) :
                new ObjectParameter("Id_Servico", typeof(int));
    
            var id_HospedagemParameter = id_Hospedagem.HasValue ?
                new ObjectParameter("Id_Hospedagem", id_Hospedagem) :
                new ObjectParameter("Id_Hospedagem", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_PedidosInserir", id_ServicoParameter, id_HospedagemParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> SP_Quarto_Tipo_PrecoLocalizar(Nullable<int> id_Quarto_Tipo)
        {
            var id_Quarto_TipoParameter = id_Quarto_Tipo.HasValue ?
                new ObjectParameter("Id_Quarto_Tipo", id_Quarto_Tipo) :
                new ObjectParameter("Id_Quarto_Tipo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("SP_Quarto_Tipo_PrecoLocalizar", id_Quarto_TipoParameter);
        }
    
        public virtual ObjectResult<string> SP_Quarto_TipoAlterar(Nullable<int> id_Quarto_Tipo, string quarto_Tipo_Descricao, Nullable<decimal> valor_Tipo_Quarto)
        {
            var id_Quarto_TipoParameter = id_Quarto_Tipo.HasValue ?
                new ObjectParameter("Id_Quarto_Tipo", id_Quarto_Tipo) :
                new ObjectParameter("Id_Quarto_Tipo", typeof(int));
    
            var quarto_Tipo_DescricaoParameter = quarto_Tipo_Descricao != null ?
                new ObjectParameter("Quarto_Tipo_Descricao", quarto_Tipo_Descricao) :
                new ObjectParameter("Quarto_Tipo_Descricao", typeof(string));
    
            var valor_Tipo_QuartoParameter = valor_Tipo_Quarto.HasValue ?
                new ObjectParameter("Valor_Tipo_Quarto", valor_Tipo_Quarto) :
                new ObjectParameter("Valor_Tipo_Quarto", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_Quarto_TipoAlterar", id_Quarto_TipoParameter, quarto_Tipo_DescricaoParameter, valor_Tipo_QuartoParameter);
        }
    
        public virtual ObjectResult<string> SP_Quarto_TipoInserir(string quarto_Tipo_Descricao, Nullable<decimal> valor_Tipo_Quarto)
        {
            var quarto_Tipo_DescricaoParameter = quarto_Tipo_Descricao != null ?
                new ObjectParameter("Quarto_Tipo_Descricao", quarto_Tipo_Descricao) :
                new ObjectParameter("Quarto_Tipo_Descricao", typeof(string));
    
            var valor_Tipo_QuartoParameter = valor_Tipo_Quarto.HasValue ?
                new ObjectParameter("Valor_Tipo_Quarto", valor_Tipo_Quarto) :
                new ObjectParameter("Valor_Tipo_Quarto", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_Quarto_TipoInserir", quarto_Tipo_DescricaoParameter, valor_Tipo_QuartoParameter);
        }
    
        public virtual ObjectResult<SP_Quarto_TipoLocalizar_Result> SP_Quarto_TipoLocalizar(string quarto_Tipo_Descricao)
        {
            var quarto_Tipo_DescricaoParameter = quarto_Tipo_Descricao != null ?
                new ObjectParameter("Quarto_Tipo_Descricao", quarto_Tipo_Descricao) :
                new ObjectParameter("Quarto_Tipo_Descricao", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Quarto_TipoLocalizar_Result>("SP_Quarto_TipoLocalizar", quarto_Tipo_DescricaoParameter);
        }
    
        public virtual ObjectResult<string> SP_QuartoAddEdit(Nullable<int> id_Quarto, string descricao, Nullable<int> id_Quarto_Tipo, Nullable<int> id_Estado_Quarto)
        {
            var id_QuartoParameter = id_Quarto.HasValue ?
                new ObjectParameter("Id_Quarto", id_Quarto) :
                new ObjectParameter("Id_Quarto", typeof(int));
    
            var descricaoParameter = descricao != null ?
                new ObjectParameter("Descricao", descricao) :
                new ObjectParameter("Descricao", typeof(string));
    
            var id_Quarto_TipoParameter = id_Quarto_Tipo.HasValue ?
                new ObjectParameter("Id_Quarto_Tipo", id_Quarto_Tipo) :
                new ObjectParameter("Id_Quarto_Tipo", typeof(int));
    
            var id_Estado_QuartoParameter = id_Estado_Quarto.HasValue ?
                new ObjectParameter("Id_Estado_Quarto", id_Estado_Quarto) :
                new ObjectParameter("Id_Estado_Quarto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_QuartoAddEdit", id_QuartoParameter, descricaoParameter, id_Quarto_TipoParameter, id_Estado_QuartoParameter);
        }
    
        public virtual ObjectResult<SP_QuartoEstadoLocalizar_Result> SP_QuartoEstadoLocalizar(string quarto)
        {
            var quartoParameter = quarto != null ?
                new ObjectParameter("Quarto", quarto) :
                new ObjectParameter("Quarto", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_QuartoEstadoLocalizar_Result>("SP_QuartoEstadoLocalizar", quartoParameter);
        }
    
        public virtual ObjectResult<SP_QuartoLocalizar_Result> SP_QuartoLocalizar(string quarto)
        {
            var quartoParameter = quarto != null ?
                new ObjectParameter("Quarto", quarto) :
                new ObjectParameter("Quarto", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_QuartoLocalizar_Result>("SP_QuartoLocalizar", quartoParameter);
        }
    
        public virtual ObjectResult<string> SP_ReservaAlterar(Nullable<int> id_Reserva, Nullable<int> id_Cliente, Nullable<int> id_Quarto, Nullable<System.DateTime> data_Entrada)
        {
            var id_ReservaParameter = id_Reserva.HasValue ?
                new ObjectParameter("Id_Reserva", id_Reserva) :
                new ObjectParameter("Id_Reserva", typeof(int));
    
            var id_ClienteParameter = id_Cliente.HasValue ?
                new ObjectParameter("Id_Cliente", id_Cliente) :
                new ObjectParameter("Id_Cliente", typeof(int));
    
            var id_QuartoParameter = id_Quarto.HasValue ?
                new ObjectParameter("Id_Quarto", id_Quarto) :
                new ObjectParameter("Id_Quarto", typeof(int));
    
            var data_EntradaParameter = data_Entrada.HasValue ?
                new ObjectParameter("Data_Entrada", data_Entrada) :
                new ObjectParameter("Data_Entrada", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_ReservaAlterar", id_ReservaParameter, id_ClienteParameter, id_QuartoParameter, data_EntradaParameter);
        }
    
        public virtual ObjectResult<string> SP_ReservaInserir(Nullable<int> id_Cliente, Nullable<int> id_Quarto, Nullable<System.DateTime> data_Entrada)
        {
            var id_ClienteParameter = id_Cliente.HasValue ?
                new ObjectParameter("Id_Cliente", id_Cliente) :
                new ObjectParameter("Id_Cliente", typeof(int));
    
            var id_QuartoParameter = id_Quarto.HasValue ?
                new ObjectParameter("Id_Quarto", id_Quarto) :
                new ObjectParameter("Id_Quarto", typeof(int));
    
            var data_EntradaParameter = data_Entrada.HasValue ?
                new ObjectParameter("Data_Entrada", data_Entrada) :
                new ObjectParameter("Data_Entrada", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_ReservaInserir", id_ClienteParameter, id_QuartoParameter, data_EntradaParameter);
        }
    
        public virtual ObjectResult<SP_ReservaLocalizar_Result> SP_ReservaLocalizar(string nome_Cliente)
        {
            var nome_ClienteParameter = nome_Cliente != null ?
                new ObjectParameter("Nome_Cliente", nome_Cliente) :
                new ObjectParameter("Nome_Cliente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ReservaLocalizar_Result>("SP_ReservaLocalizar", nome_ClienteParameter);
        }
    
        public virtual ObjectResult<string> SP_ServicoQuartoAlterar(Nullable<int> id_Servico, string servico_Descricao, Nullable<decimal> valor_Servico)
        {
            var id_ServicoParameter = id_Servico.HasValue ?
                new ObjectParameter("Id_Servico", id_Servico) :
                new ObjectParameter("Id_Servico", typeof(int));
    
            var servico_DescricaoParameter = servico_Descricao != null ?
                new ObjectParameter("Servico_Descricao", servico_Descricao) :
                new ObjectParameter("Servico_Descricao", typeof(string));
    
            var valor_ServicoParameter = valor_Servico.HasValue ?
                new ObjectParameter("Valor_Servico", valor_Servico) :
                new ObjectParameter("Valor_Servico", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_ServicoQuartoAlterar", id_ServicoParameter, servico_DescricaoParameter, valor_ServicoParameter);
        }
    
        public virtual ObjectResult<string> SP_ServicoQuartoInserir(string servico_Descricao, Nullable<decimal> valor_Servico)
        {
            var servico_DescricaoParameter = servico_Descricao != null ?
                new ObjectParameter("Servico_Descricao", servico_Descricao) :
                new ObjectParameter("Servico_Descricao", typeof(string));
    
            var valor_ServicoParameter = valor_Servico.HasValue ?
                new ObjectParameter("Valor_Servico", valor_Servico) :
                new ObjectParameter("Valor_Servico", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_ServicoQuartoInserir", servico_DescricaoParameter, valor_ServicoParameter);
        }
    
        public virtual ObjectResult<SP_ServicoQuartoLocalizar_Result> SP_ServicoQuartoLocalizar(string servico_Descricao)
        {
            var servico_DescricaoParameter = servico_Descricao != null ?
                new ObjectParameter("Servico_Descricao", servico_Descricao) :
                new ObjectParameter("Servico_Descricao", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ServicoQuartoLocalizar_Result>("SP_ServicoQuartoLocalizar", servico_DescricaoParameter);
        }
    }
}