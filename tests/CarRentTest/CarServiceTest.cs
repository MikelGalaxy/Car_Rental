using AutoMapper;
using CarRent.Data;
using CarRent.Models;
using CarRent.Profiles;
using CarRent.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CarRentTest
{
    public class CarServiceTest
    {
        private readonly CarService _testService;
        private readonly Mock<IRentalCarRepo> _repoMock = new Mock<IRentalCarRepo>();
        private readonly Mock<ILoggingService> _logger = new Mock<ILoggingService>();
        private readonly IMapper _mapper;


        public CarServiceTest()
        {
            var profile = new RentalCarProfile();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            _mapper = new Mapper(mapperConfig);
            _testService = new CarService(_repoMock.Object, _mapper, _logger.Object);
        }

        [Fact]
        public async Task GetCarById_ShouldReturnCar_WhenCarExists()
        {
            //arrange
            var id = 1;
            var brandName = "BMW";
            var car = new RentalCar
            {
                Id = id,
                Brand = brandName,
                ModelName = "M3",
                EngineCapacity = 2.5f,
                Mileage = 167_000,
                ProductionYear = 2004,
                VinNumber = "EAS42RWE32123",
                BaseRentCost = 256,
                RentalId = 23
            };

            _repoMock.Setup(x => x.GetCarByIdAsync(id))
                .ReturnsAsync(car);

            //act
            var testCar = await _testService.GetCarById(id);

            //assert
            Assert.Equal(id, testCar.Id);
            Assert.Equal(brandName, testCar.Brand);
            _logger.Verify(x => x.LoggMessage($"Car with id: {id} was found."), Times.Once);
        }

        [Fact]
        public async Task GetCarById_ShouldReturnNothing_WhenCarDoesNotExists()
        {
            //arrange
            var id = 1;

            _repoMock.Setup(x => x.GetCarByIdAsync(It.IsAny<Int32>()))
                .ReturnsAsync(() => null);

            //act
            var testCar = await _testService.GetCarById(id);

            //assert
            Assert.Null(testCar);
        }

        [Fact]
        public async Task GetCarById_ShouldReturnProperMessage_WhenCarDoesNotExists()
        {
            //arrange
            var id = 1;

            _repoMock.Setup(x => x.GetCarByIdAsync(It.IsAny<Int32>()))
                .ReturnsAsync(() => null);

            //act
            var testCar = await _testService.GetCarById(id);

            //assert
            _logger.Verify(x => x.LoggMessage($"Car with id: {id} was not found."), Times.Once);           
        }
    }
}
