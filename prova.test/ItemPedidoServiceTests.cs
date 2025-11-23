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
    public class ItemPedidoServiceTests
    {
        private Mock<IItemPedidoRepository> _repoMock = null!;
        private Mock<IUnitOfWork> _uowMock = null!;
        private ItemPedidoService _service = null!;

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IItemPedidoRepository>();
            _uowMock = new Mock<IUnitOfWork>();
            _service = new ItemPedidoService(_repoMock.Object, _uowMock.Object);
        }

        [Test]
        public async Task Add_Should_SetAtivo_CreateAndCommit()
        {
            var item = new ItemPedido { Id = Guid.NewGuid(), Produto = new Produto { Id = Guid.NewGuid(), Nome = "P", Preco = 1m }, Quantidade = 2 };

            await _service.Add(item);

            _repoMock.Verify(r => r.Create(It.Is<ItemPedido>(i => i == item)), Times.Once);
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
