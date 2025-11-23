using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using MedGrupo.DomainModel.Entity;
using MedGrupo.DomainModel.Interfaces.Repositories;
using MedGrupo.DomainModel.Interfaces.UoW;
using MedGrupo.DomainService;

namespace prova.test
{
    [TestFixture]
    public class ProdutoServiceTests
    {
        private Mock<IProdutoRepository> _repoMock = null!;
        private Mock<IUnitOfWork> _uowMock = null!;
        private ProdutoService _service = null!;

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IProdutoRepository>();
            _uowMock = new Mock<IUnitOfWork>();
            _service = new ProdutoService(_repoMock.Object, _uowMock.Object);
        }

        [Test]
        public async Task Add_Should_SetAtivo_CreateAndCommit()
        {
            var produto = new Produto { Id = Guid.NewGuid(), Nome = "X", Preco = 10m };

            await _service.Add(produto);

            _repoMock.Verify(r => r.Create(It.Is<Produto>(p => p == produto && p.Ativo)), Times.Once);
            _uowMock.Verify(u => u.CommitAsync(), Times.Once);
        }

        [Test]
        public async Task Get_Should_ReturnProduto_FromRepository()
        {
            var id = Guid.NewGuid();
            var produto = new Produto { Id = id, Nome = "X", Preco = 5m };
            _repoMock.Setup(r => r.Read(id)).ReturnsAsync(produto);

            var result = await _service.Get(id);

            Assert.AreSame(produto, result);
        }
    }
}
