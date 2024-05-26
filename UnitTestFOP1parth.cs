using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using library_for_lab10;
using MyListTests;
using lab12;


namespace MyListTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddToEnd()
        {
            //Arrange
            var myList = new MyList<Tool>();
            var item = new Tool();
            //Act
            myList.AddToEnd(item);
            //Assert
            Assert.AreEqual(1, myList.Count);
        }

        [TestMethod]
        public void RemoveItem()
        {
            // Arrange
            var myList = new MyList<Tool>();
            var item = new Tool();
            myList.AddToEnd(item);
            // Act
            bool result = myList.RemoveItem(item);
            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, myList.Count);
        }

        [TestMethod]
        public void AddToBegin()
        {
            //Arrange
            MyList<Tool> myList = new MyList<Tool>();

            //Act
            Tool tool = new Tool();
            tool.Init();
            myList.AddToBegin(tool);

            //Assert
            Assert.AreEqual(1, myList.Count);
        }

        [TestMethod]
        public void AddToEndAddingToEmptyListOneItem()
        {
            //Arrange
            MyList<Tool> myList = new MyList<Tool>();

            //Act
            Tool tool = new Tool();
            tool.Init();
            myList.AddToEnd(tool);

            //Assert
            Assert.AreEqual(1, myList.Count);
        }

        [TestMethod]
        public void RemoveItemWhenRemovingExistingItem()
        {
            //Arrange
            MyList<Tool> myList = new MyList<Tool>();
            Tool tool = new Tool();
            tool.Init();
            myList.AddToEnd(tool);

            //Act
            bool result = myList.RemoveItem(tool);

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, myList.Count);
        }

        [TestMethod]
        public void RemoveItemWhenRemovingNonExistingItem()
        {
            //Arrange
            MyList<Tool> myList = new MyList<Tool>();
            Tool tool = new Tool();
            tool.Init();
            Tool anotherTool = new Tool();
            anotherTool.Init();
            myList.AddToEnd(anotherTool);

            //Act
            bool result = myList.RemoveItem(tool);

            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(1, myList.Count);
        }

        [TestMethod]
        public void AddAfterItemWhenItemToFindNotFound()
        {
            //Arrange
            MyList<Tool> myList = new MyList<Tool>();
            Tool tool = new Tool();
            tool.Init();

            //ActAssert
            Assert.ThrowsException<Exception>(() => myList.AddAfterItem(tool, tool));
        }

        [TestMethod]
        public void FindItemWhenItemExists()
        {
            //Arrange
            MyList<Tool> myList = new MyList<Tool>();
            Tool tool = new Tool();
            tool.Init();
            myList.AddToEnd(tool);

            //Act
            var result = myList.FindItem(tool);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FindItemWhenItemDoesNotExistl()
        {
            //Arrange
            MyList<Tool> myList = new MyList<Tool>();
            Tool tool = new Tool();
            tool.Init();

            //Act
            var result = myList.FindItem(tool);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void AddsItemToEndOfList()
        {
            //Arrange
            var myList = new MyList<Tool>();

            // Act
            var tool = new Tool();
            myList.AddToEnd(tool);

            //Assert
            Assert.AreEqual(tool, myList.GetFirstItem());
        }

        public void GetFirstItemReturnsFirstItem()
        {
            //Arrange
            var myList = new MyList<Tool>();
            var expectedTool = new Tool();
            myList.AddToEnd(expectedTool);

            //Act
            var actualTool = myList.GetFirstItem();

            //Assert
            Assert.AreEqual(expectedTool, actualTool);
        }

            
    }
}
