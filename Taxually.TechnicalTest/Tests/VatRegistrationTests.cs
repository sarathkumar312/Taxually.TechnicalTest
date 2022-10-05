using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Text;
using Taxually.TechnicalTest.Controllers;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Tests
{
    [TestFixture]
    public class VatRegistrationTests
    {
        private Task<ActionResult>? mockVatRegistrationController;

        [Test]
        public void VatRegistraton_WhenCountryIsEmpty_ReturnsOk()
        {
            //Arrange
            VatRegistrationRequest vatRegistrationRequest = new VatRegistrationRequest();
            vatRegistrationRequest.Country = String.Empty;
            OkResult okResult = new OkResult();

            //Act
            VatRegistrationController vatRegistrationController = new VatRegistrationController();
            mockVatRegistrationController = vatRegistrationController.Post(vatRegistrationRequest);

            //Assert
            Assert.AreEqual(vatRegistrationController.Ok(), okResult.StatusCode);
        }
    }
}
