
using LogicaAccesoDatos;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.ImplementacionCasosUso.Atletas;
using LogicaAplicacion.ImplementacionCasosUso.Disciplinas;
using LogicaAplicacion.ImplementacionCasosUso.Eventos;
using LogicaAplicacion.ImplementacionCasosUso.Usuarios;
using LogicaAplicacion.InterfaceCasosUso.Atletas;
using LogicaAplicacion.InterfaceCasosUso.Disciplinas;
using LogicaAplicacion.InterfaceCasosUso.Eventos;
using LogicaAplicacion.InterfaceCasosUso.Usuarios;
using LogicaDeNegocio.InterfacesRepositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
            builder.Services.AddScoped<IRepositorioDisciplina, RepositorioDisciplinaEF>();
            builder.Services.AddScoped<IRepositorioAtleta, RepositorioAtletaEF>();
            builder.Services.AddScoped<IRepositorioEvento, RepositorioEventoEF>();
            builder.Services.AddScoped<IListaUsuarios, ListaUsuarios>();
            builder.Services.AddScoped<IDetalleUsuario, DetalleUsuario>();
            builder.Services.AddScoped<IListaDisciplinas, ListaDisciplinas>();
            builder.Services.AddScoped<IBuscarDisciplinaID, BuscarDisciplinaID>();
            builder.Services.AddScoped<IAltaDisciplina, AltaDisciplina>();
            builder.Services.AddScoped<IEditarDisciplina, EditarDisciplina>();
            builder.Services.AddScoped<IEliminarDisciplina, EliminarDisciplina>();
            builder.Services.AddScoped<IBuscarDisciplinaNombre, BuscarDisciplinaNombre>();
            builder.Services.AddScoped<IBuscarAtletasFiltradosPorDiscId, BuscarAtletasFiltradosPorDiscId>();
            builder.Services.AddScoped<IEventoPorDisciplinaId, EventoPorDisciplinaId>();
            builder.Services.AddScoped<IEventoPorRangoFechas, EventoPorRangoFechas>();
            builder.Services.AddScoped<IEventoPorNombreParcial, EventoPorNombreParcial>();
            builder.Services.AddScoped<IEventoPorRangoPuntajes, EventoPorRangoPuntajes>();
            builder.Services.AddScoped<IListaAtletas, ListaAtletas>();
            builder.Services.AddScoped<ILoginUsuario, LoginUsuario>();
            string cadenaConexion = builder.Configuration.GetConnectionString("CadenaConexion");
            builder.Services.AddDbContext<LibreriaContext>(opt => opt.UseSqlServer(cadenaConexion));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt => opt.IncludeXmlComments("WebAPI.xml"));

            ////Comienza JWT////
            var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";

            builder.Services.AddAuthentication(aut =>
            {
                aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(aut =>
            {
                aut.RequireHttpsMetadata = false;
                aut.SaveToken = true;
                aut.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(claveSecreta)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            //////////////////// FIN JWT ////////////////////////

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
