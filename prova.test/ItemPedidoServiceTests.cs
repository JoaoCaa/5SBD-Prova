using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Prova.DomainModel.Entity;
using Prova.DomainModel.Interfaces.Repositories;
using Prova.DomainModel.Interfaces.UoW;
using Prova.DomainService;

namespace prova.test
{
    [TestFixture]
    public class ItemPedidoServiceTests
    {
    private Mock<IItemPedidoRepository> _repoMock = null!;
    private Mock<IProdutoRepository> _produtoRepoMock = null!;
    private Mock<IUnitOfWork> _uowMock = null!;
    private ItemPedidoService _service = null!;

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IItemPedidoRepository>();
            _produtoRepoMock = new Mock<IProdutoRepository>();
            _uowMock = new Mock<IUnitOfWork>();
            _service = new ItemPedidoService(_repoMock.Object, _produtoRepoMock.Object, _uowMock.Object);
        }

        [Test]
        public async Task Add_Should_SetAtivo_CreateAndCommit()
        {
            var produto = new Produto { Id = Guid.NewGuid(), Nome = "P", Preco = 1m, Estoque = 10 };
            var item = new ItemPedido { Id = Guid.NewGuid(), ProdutoId = produto.Id, Produto = produto, Quantidade = 2, Preco = produto.Preco };

            _produtoRepoMock.Setup(p => p.Read(produto.Id)).ReturnsAsync(produto);

            await _service.Add(item);

            _repoMock.Verify(r => r.Create(It.Is<ItemPedido>(i => i == item)), Times.Once);
            _produtoRepoMock.Verify(p => p.Update(It.Is<Produto>(pr => pr.Id == produto.Id && pr.Estoque == 8)), Times.Once);
            _uowMock.Verify(u => u.CommitAsync(), Times.Once);
        }

        [Test]
        public async Task Get_Should_ReturnItem_FromRepository()
        {
            var id = Guid.NewGuid();
            var item = new ItemPedido { Id = id, Produto = new Produto { Id = Guid.NewGuid(), Nome = "P", Preco = 1m }, Quantidade = 3 };
            _repoMock.Setup(r => r.Read(id)).ReturnsAsync(item);

            var result = await _service.Get(id);

            Assert.AreSame(item, result);
        }
    }
}
