using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiThrottle.Net;
using Xunit;

namespace WebApiThrottle.Tests
{
    public class IpAddressUtilTests
    {
        [Fact]
        public void IsPrivateIpAddress_PrivateAddress_ReturnsTrue()
        {
            bool result = IpAddressUtil.IsPrivateIpAddress("10.0.0.1");

            Assert.Equal(true, result);
        }

        [Fact]
        public void IsPrivateIpAddress_PublicAddress_ReturnsFalse()
        {
            bool result = IpAddressUtil.IsPrivateIpAddress("8.8.8.8");

            Assert.Equal(false, result);
        }
        
        [Fact]
        public void IsPrivateIpAddress_PublicAddressIpv6_ReturnsFalse()
        {
            bool result = IpAddressUtil.IsPrivateIpAddress("2001:4860:4860::8888");

            Assert.Equal(false, result);
        }

        [Fact]
        public void IsPrivateIpAddress_PrivateAddressIpv6_ReturnsFalse()
        {
            bool result = IpAddressUtil.IsPrivateIpAddress("fd74:20cf:81a2::");

            Assert.Equal(true, result);
        }

        [Fact]
        public void IsPrivateIpAddress_PrivateAddressWithPort_ReturnsTrue()
        {
            bool result = IpAddressUtil.IsPrivateIpAddress("10.0.0.1:5555");

            Assert.Equal(true, result);
        }

        [Fact]
        public void IsPrivateIpAddress_PrivateAddressIpv6WithPort_ReturnsTrue()
        {
            bool result = IpAddressUtil.IsPrivateIpAddress("[fd74:20cf:81a2::]:5555");

            Assert.Equal(true, result);
        }

        [Fact]
        public void IsPrivateIpAddress_PublicIpAddressWithInitialSpace_ReturnsFalse()
        {
            bool result = IpAddressUtil.IsPrivateIpAddress(" 8.8.8.8");

            Assert.Equal(false, result);
        }

        [Fact]
        public void Faz_uso_do_header_da_akamai()
        {
            var http = new HttpRequestMessage();
            http.Headers.Add("X-Forwarded-For", "177.96.44.32, 23.50.52.13, 23.50.52.23");
            http.Headers.Add("True-Client-IP", "127.0.0.1");
            
            var ip = http.GetClientIpAddress();
            var i = IpAddressUtil.ParseIp(ip);
        }
    }
}
