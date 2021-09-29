using AutoMapper;
using Channel9.Challenge;
using Channel9.Challenge.Controllers;
using Channel9.Challenge.Dto;
using Channel9.Challenge.Mapper;
using Channel9.Challenge.Models;
using Channel9.Challenge.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class TVCommercialControllerTests
    {
        private readonly ITVCommercialService _service;
        private readonly IMapper _mapper;
        private readonly TVCommercialController _sut;


        public TVCommercialControllerTests()
        {
            _service = Substitute.For<ITVCommercialService>();
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();
            _sut = new TVCommercialController(_service, _mapper);
        }

        [Test]
        public void ProcessCommercialBreaks_Should_Return_Response_When_Service_Is_Successful()
        {
            // Arrange
            Dictionary<string, int> rules = new Dictionary<string, int> { { "Break1", 2 }, { "Break2", 3 }, { "Break3", 4 } };
            var mockResponse = new List<CommercialBreak>
            {
                new CommercialBreak
                {
                    BreakId = "FAKE_BREAK_ID",
                    Commercials = new List<BreakCommercial>
                    { new BreakCommercial
                        {
                            CommercialId ="FAKE_COMMERCIAL_ID", Demography=DemographicType.M_18_35, Rating=50, Type=CommercialType.Automotive
                        }
                    }
                }
            };

            var expectedResponse = _mapper.Map<List<CommercialBreak>, List<OptimizedCommercialBreak>>(mockResponse);
            _service.GetOptimizedCommercialBreaks(Arg.Is(rules)).Returns(mockResponse);

            // Act
            var response = _sut.ProcessCommercialBreaks(rules);
            var result = response as OkObjectResult;

            // Assert
            result.Value.Should().BeEquivalentTo(expectedResponse);
        }

        [Test]
        public void ProcessCommercialBreaks_Should_Return_Error_When_Service_Throws_Exception()
        {
            // Arrange
            Dictionary<string, int> rules = new Dictionary<string, int> { { "Break1", 2 }, { "Break2", 3 }, { "Break3", 4 } };
            var mockResponse = new List<CommercialBreak>
            {
                new CommercialBreak
                {
                    BreakId = "FAKE_BREAK_ID",
                    Commercials = new List<BreakCommercial>
                    { new BreakCommercial
                        {
                            CommercialId ="FAKE_COMMERCIAL_ID", Demography=DemographicType.M_18_35, Rating=50, Type=CommercialType.Automotive
                        }
                    }
                }
            };

            var expectedResponse = _mapper.Map<List<CommercialBreak>, List<OptimizedCommercialBreak>>(mockResponse);
            _service.GetOptimizedCommercialBreaks(Arg.Is(rules)).Throws(new Exception("something went wrong"));

            // Act & Assert
            Assert.Throws(typeof(Exception),()=>_sut.ProcessCommercialBreaks(rules));           
        }
    }
}