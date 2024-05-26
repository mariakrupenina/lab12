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

        public void GetFirstItem_ReturnsFirstItem()
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
        [TestClass]
        public class UnitTest2
        {
            [TestMethod]
            public void AddItemWhenCapacityExceeded()
            {
                //Arrange
                var hashTable = new MyHashTable2<Tool>(2, 0.72); //ёмкость 2, заполненность 72%
                hashTable.AddItem3(new Tool()); //первое добавление

                //Act
                hashTable.AddItem3(new Tool()); //второе добавление

                //Assert
                Assert.AreEqual(4, hashTable.Capacity); //ожидаем, что ёмкость увеличена до 4
            }

            [TestMethod]
            public void AddItem2WhenTableIsEmpty()
            {
                //Arrange
                var hashTable = new MyHashTable2<Tool>();

                //Act
                hashTable.AddItem3(new Tool());

                //Assert
                Assert.AreEqual(1, hashTable.Count); //Ожидаем, что количество элементов равно 1
            }

            [TestMethod]
            public void AddItemWhenTableIsNotEmpty()
            {
                //Arrange
                var hashTable = new MyHashTable2<Tool>();
                hashTable.AddItem3(new Tool()); 

                //Act
                hashTable.AddItem3(new Tool()); 

                //Assert
                Assert.AreEqual(2, hashTable.Count); //Ожидаем, что количество элементов равно 2
            }

            [TestMethod]
            public void RemoveItemWhenItemExists()
            {
                //Arrange
                var hashTable = new MyHashTable2<Tool>();
                var tool = new Tool();
                hashTable.AddItem3(tool); //добавляем элемент

                //Act
                bool removed = hashTable.RemoveItem(tool);

                //Assert
                Assert.IsTrue(removed); //ожидаем удаление
                Assert.AreEqual(0, hashTable.Count); //ожидаем, что количество элементов уменьшилось до 0
            }

            [TestMethod]
            public void AddItemWhenTableIsEmpty()
            {
                //Arrange
                var hashTable = new MyHashTable2<Tool>();
                var newTool = new Tool();

                //Act
                hashTable.AddItem3(newTool);

                //Assert
                Assert.AreEqual(1, hashTable.Count);
                Assert.IsTrue(hashTable.Contains(newTool));
            }

            [TestMethod]
            public void RemoveItemWhenItemExist()
            {
                //Arrange
                var hashTable = new MyHashTable2<Tool>();
                var toolToRemove = new Tool();
                hashTable.AddItem3(toolToRemove);

                //Act
                bool removed = hashTable.RemoveItem(toolToRemove);

                //Assert
                Assert.IsTrue(removed);
                Assert.AreEqual(0, hashTable.Count);
                Assert.IsFalse(hashTable.Contains(toolToRemove));
            }

            [TestMethod]
            public void ContainsWhenItemExists()
            {
                //Arrange
                var hashTable = new MyHashTable2<Tool>();
                var existingTool = new Tool();
                hashTable.AddItem3(existingTool);

                //Act
                bool result = hashTable.Contains(existingTool);

                //Assert
                Assert.IsTrue(result);
            }

            [TestMethod]
            public void ContainsWhenItemNotExist()
            {
                //Arrange
                var hashTable = new MyHashTable2<Tool>();
                var nonExistingTool = new Tool();

                //Act
                bool result = hashTable.Contains(nonExistingTool);

                //Assert
                Assert.IsFalse(result);
            }
        }
    }
}
