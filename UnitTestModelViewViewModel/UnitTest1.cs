using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GalaSoft.MvvmLight.Command;
using ModelViewViewModel.ViewModels;
using ModelViewViewModel.Models;

namespace UnitTestModelViewViewModel
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        /// Jde o to, že tento test můžeme spustit kdykoliv i bez toho,
        /// že bychom sestavovali celou aplikaci a test může proběhnout
        /// bez manuální intervence = kliknutí na tlačítko 
        /// <Button Grid.Row="1" Content="Odeslat" Command="{Binding SendCommand}"/>
        /// v Page1.xaml, které jsme na příkaz SendCommand navázali.
        /// V tomto testu ověřujeme, že se přiřazení do vlastnosti Zprava a
        /// spuštění příkazu SendCommand projeví tím,
        /// že se v modelu aktualizuje pole VsechnyZpravy ze ZpravaModel
        /// 
        /// Protože reálné aplikace mají desítky tlačítek a navázaných akcí
        /// a složitou logiku práce s daty (ne jenom ukládání do pole, 
        /// ale parsování, výpočty, spolupráce s dalšími programy, apod.), 
        /// může takováto konfigurace ušetřit týdny času v rámci většího projektu.
        /// To není kosmetická záležitost!
        public void TestMethod1()
        {
            // Arrange
            string testMessage = "Unit test zprava";
            ZpravaModel z = new ZpravaModel();
            ZpravaViewModel zvm = new ZpravaViewModel();

            // Act
            // Tohle za nás v aplikaci udělá binding
            // na TextBox a Button. V testu to dokážeme simulovat voláním.
            zvm.Zprava = testMessage; 
            zvm.SendCommand.Execute(null);
            
            // Assert
            // Ověř, že se zpráva dostala do datového modelu
            Assert.AreEqual(ZpravaModel.VsechnyZpravy[0], testMessage);
        }
    }
}
