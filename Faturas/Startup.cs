using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Faturas.Data;
using Faturas.Models;
using Faturas.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Faturas
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FaturasContext>(opt =>
               opt.UseInMemoryDatabase("Faturas"));
            services.AddMvc();

            services.AddScoped<IFaturasRepositorio, FaturasRepositorio>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p =>
                {
                    p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                }

                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<Entidades.Cliente, Models.ClienteDTO>();
                cfg.CreateMap<Entidades.Produto, Models.ProdutoDTO>();
                cfg.CreateMap<Entidades.Linha, Models.LinhaDTO>();
                cfg.CreateMap<Entidades.Fatura, Models.FaturaDTO>().ForMember(m => m.LinhaDTO, opt => opt.MapFrom(src =>  Mapper.Map<IEnumerable<LinhaDTO>>(src.Linha) ));


                cfg.CreateMap<Entidades.Transacao, Models.TransacaoDTO>();
                cfg.CreateMap<Entidades.Pagamento, Models.PagamentoDTO>();
                cfg.CreateMap<Entidades.Banco, Models.BancoDTO>();
                cfg.CreateMap<Entidades.ContaBancaria, Models.ContaBancariaDTO>();
                cfg.CreateMap<Entidades.MovimentoBancario, Models.MovimentoBancarioDTO>();
                cfg.CreateMap<Entidades.ReceitaOrcamento, Models.ReceitaOrcamentoDTO>();
                cfg.CreateMap<Entidades.Funcionario, Models.FuncionarioDTO>();

            });

            app.UseCors(c => c.WithOrigins("http://localhost:4200").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()           
            );
            app.UseMvc();
        }
    }
}
