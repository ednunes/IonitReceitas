using Ionit.Receitas.Core.Entities;
using Ionit.Receitas.Core.Interfaces.Services.Application;
using Ionit.Receitas.Core.Interfaces.Services.Domain;
using Ionit.Receitas.Core.Services.Application;
using Moq;
using System;
using Xunit;

namespace Ionit.Receitas.Test
{
    public class UnitTest1
    {
        [Fact]
        public void criando_uma_nova_receita()
        {
            var domainService = new Mock<IDomainService<ReceitaDto>>();

            //Instancia da dto Receita
            var receita = new Mock<ReceitaDto>();

            var receitaService = new ReceitaAppService(domainService.Object);

            domainService.Setup(x => x.Inserir(receita.Object)).Returns(1);

            

            receita.SetupGet(x => x.Id).Returns(1);

            Assert.Equal(0, receitaService.Inserir(receita.Object));
        }
    }
}
