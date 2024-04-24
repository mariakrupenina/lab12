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
        public void RemoveUntilItemWhenItemToRemoveNotFound()
        {
            //Arrange
            MyList<Tool> myList = new MyList<Tool>();
            Tool tool = new Tool();
            tool.Init();

            //ActAssert
            Assert.ThrowsException<Exception>(() => myList.RemoveUntilItem(tool));
        }

        [TestMethod]
        public void RemoveUntilItemWhenItemToRemoveExists()
        {
            //Arrange
            MyList<Tool> myList = new MyList<Tool>();
            Tool tool1 = new Tool();
            Tool tool2 = new Tool();
            Tool tool3 = new Tool();
            tool1.Init();
            tool2.Init();
            tool3.Init();
            myList.AddToEnd(tool1);
            myList.AddToEnd(tool2);
            myList.AddToEnd(tool3);

            //Act
            myList.RemoveUntilItem(tool2);

            //Assert
            Assert.AreEqual(1, myList.Count);
            Assert.AreEqual(tool2, myList.beg.Data);
        }
    }
}
