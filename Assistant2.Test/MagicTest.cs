﻿using System;
using System.Collections.Generic;
using Assistant2.Models;
using Assistant2.Services.Magic;
using Assistant2.Services.Magic.Updater;
using Assistant2.Util;
using NUnit.Framework;

namespace TestProject1;

[TestFixture]
public class MagicTest
{
    [TestCase("vmess://test", ExpectedResult = true)]
    [TestCase("trojan://test", ExpectedResult = false)]
    [TestCase("ss://test", ExpectedResult = false)]
    [TestCase("vless://test", ExpectedResult = false)]
    public bool V2CheckTest(string input)
    {
        return MagicUtil.CheckV2Format(input);
    }

    [Test]
    public void TempTest()
    {
        var updater = new V2Updater(new MagicSubscribe
        {
            Data =
                "dm1lc3M6Ly9leUoySWpvaU1pSXNJbkJ6SWpvaVhIVTVPVGs1WEhVMlpUSm1JREEySWl3aVlXUmtJam9pYmpRdWJuVm1jM2d1ZEc5d0lpd2ljRzl5ZENJNklqSTBNVEF6SWl3aWFXUWlPaUptTVdGbU1EVmtaQzB6TVRrNUxUUXdNemd0WWprelpDMWhNREF4WldVMk1USmpORFFpTENKaGFXUWlPaUl3SWl3aWJtVjBJam9pZDNNaUxDSjBlWEJsSWpvaWJtOXVaU0lzSW1odmMzUWlPaUlpTENKd1lYUm9Jam9pWEM4eE1UUTFNVFF1WVhCcklpd2lkR3h6SWpvaUluMD0NCnZtZXNzOi8vZXlKMklqb2lNaUlzSW5Ceklqb2lYSFU1T1RrNVhIVTJaVEptSURBMUlpd2lZV1JrSWpvaWJqQXVjMmRrYm5NdVkyeDFZaUlzSW5CdmNuUWlPaUl5TXpFd01DSXNJbWxrSWpvaVpqRmhaakExWkdRdE16RTVPUzAwTURNNExXSTVNMlF0WVRBd01XVmxOakV5WXpRMElpd2lZV2xrSWpvaU1DSXNJbTVsZENJNkluZHpJaXdpZEhsd1pTSTZJbTV2Ym1VaUxDSm9iM04wSWpvaUlpd2ljR0YwYUNJNklsd3ZNVEUwTlRFMExtRndheUlzSW5Sc2N5STZJaUo5DQp2bWVzczovL2V5SjJJam9pTWlJc0luQnpJam9pWEhVMk5XVTFYSFUyTnpKaklEQTFJaXdpWVdSa0lqb2liakV1YzJka2JuTXVZMngxWWlJc0luQnZjblFpT2lJeU16RXdNU0lzSW1sa0lqb2laakZoWmpBMVpHUXRNekU1T1MwME1ETTRMV0k1TTJRdFlUQXdNV1ZsTmpFeVl6UTBJaXdpWVdsa0lqb2lNQ0lzSW01bGRDSTZJbmR6SWl3aWRIbHdaU0k2SW01dmJtVWlMQ0pvYjNOMElqb2lJaXdpY0dGMGFDSTZJbHd2TVRFME5URTBMbUZ3YXlJc0luUnNjeUk2SWlKOQ0Kdm1lc3M6Ly9leUoySWpvaU1pSXNJbkJ6SWpvaVhIVTJOV1UxWEhVMk56SmpJREEySWl3aVlXUmtJam9pYmpFdWMyY3hNREkwTG5oNWVpSXNJbkJ2Y25RaU9pSXlOakV3TlNJc0ltbGtJam9pWmpGaFpqQTFaR1F0TXpFNU9TMDBNRE00TFdJNU0yUXRZVEF3TVdWbE5qRXlZelEwSWl3aVlXbGtJam9pTUNJc0ltNWxkQ0k2SW5keklpd2lkSGx3WlNJNkltNXZibVVpTENKb2IzTjBJam9pSWl3aWNHRjBhQ0k2SWx3dk1URTBOVEUwTG1Gd2F5SXNJblJzY3lJNklpSjkNCnZtZXNzOi8vZXlKMklqb2lNaUlzSW5Ceklqb2lYSFUxTTJZd1hIVTJaVGRsSURBMUlpd2lZV1JrSWpvaWJqSXVjMmRrYm5NdVkyeDFZaUlzSW5CdmNuUWlPaUl5TXpFd01pSXNJbWxrSWpvaVpqRmhaakExWkdRdE16RTVPUzAwTURNNExXSTVNMlF0WVRBd01XVmxOakV5WXpRMElpd2lZV2xrSWpvaU1DSXNJbTVsZENJNkluZHpJaXdpZEhsd1pTSTZJbTV2Ym1VaUxDSm9iM04wSWpvaUlpd2ljR0YwYUNJNklsd3ZNVEUwTlRFMExtRndheUlzSW5Sc2N5STZJaUo5DQp2bWVzczovL2V5SjJJam9pTWlJc0luQnpJam9pWEhVNVlUWmpYSFUyTnpZMVhIVTRPVGRtWEhVMFpUbGhJREExSWl3aVlXUmtJam9pYmpNdU1UQjBlaTUwYjNBaUxDSndiM0owSWpvaU16VXhNallpTENKcFpDSTZJbVl4WVdZd05XUmtMVE14T1RrdE5EQXpPQzFpT1ROa0xXRXdNREZsWlRZeE1tTTBOQ0lzSW1GcFpDSTZJakFpTENKdVpYUWlPaUozY3lJc0luUjVjR1VpT2lKdWIyNWxJaXdpYUc5emRDSTZJaUlzSW5CaGRHZ2lPaUpjTHpFeE5EVXhOQzVoY0dzaUxDSjBiSE1pT2lJaWZRPT0NCnZtZXNzOi8vZXlKMklqb2lNaUlzSW5Ceklqb2lYSFUzWmpobFhIVTFObVprSURBMUlpd2lZV1JrSWpvaWJqTXVjMmRrYm5NdVkyeDFZaUlzSW5CdmNuUWlPaUl5TXpFd015SXNJbWxrSWpvaVpqRmhaakExWkdRdE16RTVPUzAwTURNNExXSTVNMlF0WVRBd01XVmxOakV5WXpRMElpd2lZV2xrSWpvaU1DSXNJbTVsZENJNkluZHpJaXdpZEhsd1pTSTZJbTV2Ym1VaUxDSm9iM04wSWpvaUlpd2ljR0YwYUNJNklsd3ZNVEUwTlRFMExtRndheUlzSW5Sc2N5STZJaUo5DQp2bWVzczovL2V5SjJJam9pTWlJc0luQnpJam9pWEhVNU4yVTVYSFUxTm1aa0lEQTFJaXdpWVdSa0lqb2liakV1Ym5WbWMzZ3VkRzl3SWl3aWNHOXlkQ0k2SWpJME1UQXdJaXdpYVdRaU9pSm1NV0ZtTURWa1pDMHpNVGs1TFRRd016Z3RZamt6WkMxaE1EQXhaV1UyTVRKak5EUWlMQ0poYVdRaU9pSXdJaXdpYm1WMElqb2lkM01pTENKMGVYQmxJam9pYm05dVpTSXNJbWh2YzNRaU9pSWlMQ0p3WVhSb0lqb2lYQzh4TVRRMU1UUXVZWEJySWl3aWRHeHpJam9pSW4wPQ0Kdm1lc3M6Ly9leUoySWpvaU1pSXNJbkJ6SWpvaVhIVTJOV0l3WEhVMU1tRXdYSFUxTnpZeElEQTFJaXdpWVdSa0lqb2liakl1Ym5WbWMzZ3VkRzl3SWl3aWNHOXlkQ0k2SWpJME1UQXhJaXdpYVdRaU9pSm1NV0ZtTURWa1pDMHpNVGs1TFRRd016Z3RZamt6WkMxaE1EQXhaV1UyTVRKak5EUWlMQ0poYVdRaU9pSXdJaXdpYm1WMElqb2lkM01pTENKMGVYQmxJam9pYm05dVpTSXNJbWh2YzNRaU9pSWlMQ0p3WVhSb0lqb2lYQzh4TVRRMU1UUXVZWEJySWl3aWRHeHpJam9pSW4wPQ0Kc3M6Ly9ZV1Z6TFRJMU5pMW5ZMjA2WmpGaFpqQTFaR1F0TXpFNU9TMDBNRE00TFdJNU0yUXRZVEF3TVdWbE5qRXlZelEwQGlwbGNuYXQuY29jb3l5ZHMubmV0OjExNDA1IyVFOSVBNiU5OSVFNiVCOCVBRiUyMDFNJTIwJUUyJTk4JTg1DQo="
        });
        updater.UpdateSubInfo();
    }
}