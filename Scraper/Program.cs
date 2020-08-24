using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Scraper
{

    //quick  and dirty :)
    class Program
    {
        static void Main(string[] args)
        {
            //Initializing List
            List<EntryModel> Data = new List<EntryModel>();

            //Getting tarted on the first page

            IWebDriver driver = new ChromeDriver();
            var id = 1;
            driver.Navigate().GoToUrl("https://www.voedingswaardetabel.nl/voedingswaarde/voedingsmiddel/?id=" + id);
            Thread.Sleep(6000);
            IWebElement body = driver.FindElement(By.TagName("body"));
            IWebElement iframe = body.FindElement(By.TagName("iframe"));
            driver.SwitchTo().Frame(iframe);
            var button = driver.FindElement(By.Id("acceptAll"));
            button.Click();
            Data.Clear();

            for (var i = 2; i < 1370; i++)
            {

                IWebElement SearchFrom;
                //Locating the first 2 rowitems
                try
                {
                    SearchFrom = driver.FindElement(By.Id("prodgramsanchor"));
                }
                catch
                {

                    Console.WriteLine($"Could  not find 'SEARCHFORM' with id: {id}");
                    driver.Navigate().GoToUrl("https://www.voedingswaardetabel.nl/voedingswaarde/voedingsmiddel/?id=" + i);
                    continue;
                }

                var rowitems = SearchFrom.FindElements(By.ClassName("rowitem"));
                var rowitem1 = rowitems[0];
                var rowitem2 = rowitems[1];
                var waarde1 = rowitem1.FindElement(By.ClassName("floatright")).Text;
                var waarde2 = rowitem2.FindElement(By.ClassName("floatright")).Text;

                IWebElement searchForColumnRight = driver.FindElement(By.ClassName("ColumnRight"));
                var allPTags = searchForColumnRight.FindElements(By.TagName("p"));
                var description = allPTags[0].Text;


                // Adding scraped values to variables
                var productName = driver.FindElement(By.TagName("h2"))?.Text;
                var productGroup = driver.FindElement(By.Id("ctl00_cphMain_hplPrdGrp")).Text;

                var parsedGevoelswaarde = double.TryParse(waarde1, out double w1);
                var parsedGezonheidswaarde = double.TryParse(waarde2, out double w2);




                var gevoelsWaarde = parsedGevoelswaarde ? w1 : 0;
                var gezondheidsWaarde = parsedGezonheidswaarde ? w2 : 0;


                double portionInGrams;
                try
                {
                    portionInGrams = double.TryParse(driver.FindElement(By.Id("gpp")).Text, out double w) ? w : 0;
                }
                catch
                {
                    portionInGrams = 100.0;

                }

                var kcal = double.TryParse(driver.FindElement(By.Id("lblKcal")).Text, out double w3) ? w3 : 0;
                var kJoule = double.TryParse(driver.FindElement(By.Id("lblKjoule")).Text, out double w5) ? w5 : 0;
                var water = double.TryParse(driver.FindElement(By.Id("lblWater")).Text, out double w6) ? w6 : 0;
                var proteine = double.TryParse(driver.FindElement(By.Id("lblEiwit")).Text, out double w7) ? w7 : 0;
                var fat = double.TryParse(driver.FindElement(By.Id("lblVet")).Text, out double w8) ? w8 : 0;
                var saturatedFat = double.TryParse(driver.FindElement(By.Id("lblVerz")).Text, out double w9) ? w9 : 0;
                var sNotSaturatedFat = double.TryParse(driver.FindElement(By.Id("lblEov")).Text, out double w10) ? w10 : 0;
                var pNotSaturatedFat = double.TryParse(driver.FindElement(By.Id("lblMov")).Text, out double w11) ? w11 : 0;
                var cholestrol = double.TryParse(driver.FindElement(By.Id("lblChol")).Text, out double w12) ? w12 : 0;
                var carbs = double.TryParse(driver.FindElement(By.Id("lblKoolh")).Text, out double w13) ? w13 : 0;
                var sugar = double.TryParse(driver.FindElement(By.Id("lblSuikers")).Text, out double w14) ? w14 : 0;
                var fibers = double.TryParse(driver.FindElement(By.Id("lblVoedv")).Text, out double w15) ? w15 : 0;

                var vitA = double.TryParse(driver.FindElement(By.Id("lblVitA")).Text, out double v1) ? v1 : 0;
                var vitB1 = double.TryParse(driver.FindElement(By.Id("lblVitB1")).Text, out double v2) ? v2 : 0;
                var vitB2 = double.TryParse(driver.FindElement(By.Id("lblVitB2")).Text, out double v3) ? v3 : 0;
                var vitB6 = double.TryParse(driver.FindElement(By.Id("lblVitB6")).Text, out double v4) ? v4 : 0;
                var vitB11 = double.TryParse(driver.FindElement(By.Id("lblVitB11")).Text, out double v5) ? v5 : 0;
                var vitB12 = double.TryParse(driver.FindElement(By.Id("lblVitB12")).Text, out double v6) ? v6 : 0;
                var vitC = double.TryParse(driver.FindElement(By.Id("lblVitC")).Text, out double v7) ? v7 : 0;
                var vitD = double.TryParse(driver.FindElement(By.Id("lblVitD")).Text, out double v8) ? v8 : 0;

                var natrium = double.TryParse(driver.FindElement(By.Id("lblMinNa")).Text, out double m1) ? m1 : 0;
                var kalium = double.TryParse(driver.FindElement(By.Id("lblMinK")).Text, out double m2) ? m2 : 0;
                var calcium = double.TryParse(driver.FindElement(By.Id("lblMinCa")).Text, out double m3) ? m3 : 0;
                var fosfor = double.TryParse(driver.FindElement(By.Id("lblMinP")).Text, out double m4) ? m4 : 0;
                var ijzer = double.TryParse(driver.FindElement(By.Id("lblMinFe")).Text, out double m5) ? m5 : 0;
                var magnesium = double.TryParse(driver.FindElement(By.Id("lblMinMg")).Text, out double m6) ? m6 : 0;
                var koper = double.TryParse(driver.FindElement(By.Id("lblMinCu")).Text, out double m7) ? m7 : 0;
                var zink = double.TryParse(driver.FindElement(By.Id("lblMinZn")).Text, out double m8) ? m8 : 0;

                //assigning scraped values to EntryModel Object

                var entry = new EntryModel();

                entry.ProductNaam = productName;
                entry.ProductGroep = productGroup;
                entry.Beschrijving = description;
                entry.Gevoelswaarde = gevoelsWaarde;
                entry.Gezondheidswaarde = gezondheidsWaarde;
                entry.ProductGewichtPortie = portionInGrams;
                entry.Kcal = kcal;
                entry.KJoule = kJoule;
                entry.Water = water;
                entry.Proteine = proteine;
                entry.Vet = fat;
                entry.VerzadigdVet = saturatedFat;
                entry.EnkelvoudigVerzadigdVet = sNotSaturatedFat;
                entry.MeervoudigVerzadigdVet = pNotSaturatedFat;
                entry.Cholestrol = cholestrol;
                entry.Koolhydraten = carbs;
                entry.Suikers = sugar;
                entry.Voedingsvezels = fibers;

                entry.VitamineA = vitA;
                entry.VitamineB1 = vitB1;
                entry.VitamineB2 = vitB2;
                entry.VitamineB6 = vitB6;
                entry.VitamineB11 = vitB11;
                entry.VitamineB12 = vitB12;
                entry.VitamineC = vitC;
                entry.VitamineD = vitD;

                entry.Natrium = natrium;
                entry.Kalium = kalium;
                entry.Calcium = calcium;
                entry.FosFor = fosfor;
                entry.Ijzer = ijzer;
                entry.Magnesium = magnesium;
                entry.Koper = koper;
                entry.Zink = zink;


                var entryString = JsonConvert.SerializeObject(entry, Formatting.Indented);
                File.WriteAllText($"C:\\scrapeWithDescription1\\{i}.json", entryString);
                

                //add entrymodel object in to list Data

                Data.Add(entry);

                Thread.Sleep(3000);
                driver.Navigate().GoToUrl("https://www.voedingswaardetabel.nl/voedingswaarde/voedingsmiddel/?id=" + i);
                Thread.Sleep(3000);
            }

            //Data.Clear();

            //List<EntryModel> entries = new List<EntryModel>();
            //for (var i = 2; i < 1370; i++)
            //{
            //    if (!File.Exists($"C:\\scrapeWithDescription\\{i}.json")) continue;
            //    var content = File.ReadAllText($"C:\\scrapeWithDescription1\\{i}.json");
            //    var pContent = JsonConvert.DeserializeObject<EntryModel>(content);
            //    entries.Add(pContent);





        }



    }


}


