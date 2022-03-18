namespace E02.DOM.Tests
{
    using NUnit.Framework;
    using System.Linq;
    using EP02.DOM.Interfaces;
    using EP02.DOM.Models;
    using EP02.DOM;

    class DomUnitTests
    {
        private IDocument _document;
        private IHtmlElement _listItem;
        private IHtmlElement _ulElement;
        private IHtmlElement _secondUlEmement;
        private IHtmlElement _thirdUlElement;

        [Test]
        public void TestFirstConstructorSetsCorrectElements()
        {
            this._document = new DocumentObjectModel(
                 new HtmlElement(ElementType.Document,
                     new HtmlElement(ElementType.Html,
                         new HtmlElement(ElementType.Head),
                         new HtmlElement(ElementType.Body,
                             new HtmlElement(ElementType.Paragraph),
                             new HtmlElement(ElementType.Div),
                             new HtmlElement(ElementType.Span),
                             new HtmlElement(ElementType.UnorderedList,
                                 new HtmlElement(ElementType.ListItem),
                                 new HtmlElement(ElementType.ListItem),
                                 new HtmlElement(ElementType.ListItem)
                             )
                         )
                     )
                 )
             );

            var root = this._document.Root;
            var rootChildren = root.Children;

            Assert.IsNotNull(root);
            Assert.IsNotNull(root.Children);
            Assert.AreEqual(ElementType.Html, rootChildren[0].Type);

            var htmlChildren = rootChildren[0].Children;
            Assert.IsNotNull(htmlChildren);
            Assert.AreEqual(ElementType.Head, htmlChildren[0].Type);
            Assert.AreEqual(ElementType.Body, htmlChildren[1].Type);

            var bodyChildren = htmlChildren[1].Children;
            Assert.IsNotNull(bodyChildren);
            Assert.AreEqual(ElementType.Paragraph, bodyChildren[0].Type);
            Assert.AreEqual(ElementType.Div, bodyChildren[1].Type);
            Assert.AreEqual(ElementType.Span, bodyChildren[2].Type);
            Assert.AreEqual(ElementType.UnorderedList, bodyChildren[3].Type);

            var ulChildren = bodyChildren[3].Children;
            Assert.IsNotNull(ulChildren);
            Assert.IsTrue(ulChildren.All(ch => ch.Type == ElementType.ListItem));
        }

        [Test]
        public void TestContainsReturnsTrue()
        {
            this._listItem = new HtmlElement(ElementType.ListItem);

            this._document = new DocumentObjectModel(
                new HtmlElement(ElementType.Document,
                    new HtmlElement(ElementType.Html,
                        new HtmlElement(ElementType.Head),
                        new HtmlElement(ElementType.Body,
                            new HtmlElement(ElementType.Paragraph),
                            new HtmlElement(ElementType.Div),
                            new HtmlElement(ElementType.Span),
                            new HtmlElement(ElementType.UnorderedList,
                                new HtmlElement(ElementType.ListItem),
                                new HtmlElement(ElementType.ListItem),
                                this._listItem
                            )
                        )
                    )
                )
            );

            Assert.IsTrue(this._document.Contains(this._listItem));
        }

        [Test]
        public void TestGetElementByTypeReturnsCorrectElement()
        {
            this._document = new DocumentObjectModel(
                new HtmlElement(ElementType.Document,
                    new HtmlElement(ElementType.Html,
                        new HtmlElement(ElementType.Head),
                        new HtmlElement(ElementType.Body,
                            new HtmlElement(ElementType.Paragraph),
                            new HtmlElement(ElementType.Div),
                            new HtmlElement(ElementType.Span),
                            new HtmlElement(ElementType.UnorderedList,
                                new HtmlElement(ElementType.ListItem),
                                new HtmlElement(ElementType.ListItem),
                                new HtmlElement(ElementType.ListItem)
                            )
                        )
                    )
                )
            );

            var listItem = this._document.GetElementByType(ElementType.ListItem);

            Assert.IsNotNull(listItem);
            Assert.AreEqual(ElementType.ListItem, listItem.Type);
        }

        [Test]
        public void TestGetElementsByTypeReturnsElementsInDfsOrder()
        {
            this._document = new DocumentObjectModel(
            new HtmlElement(ElementType.Document,
                new HtmlElement(ElementType.Html,
                    new HtmlElement(ElementType.Head),
                    new HtmlElement(ElementType.Body,
                        new HtmlElement(ElementType.Paragraph),
                        new HtmlElement(ElementType.Div),
                        new HtmlElement(ElementType.Anchor),
                        new HtmlElement(ElementType.Anchor,
                            new HtmlElement(ElementType.Anchor)),
                        new HtmlElement(ElementType.UnorderedList,
                            new HtmlElement(ElementType.Anchor,
                                new HtmlElement(ElementType.Anchor),
                                new HtmlElement(ElementType.Anchor)),
                            new HtmlElement(ElementType.ListItem),
                            new HtmlElement(ElementType.ListItem)
                        )
                    )
                )
            )
        );

            var anchors = this._document.GetElementsByType(ElementType.Anchor);

            Assert.IsNotNull(anchors);
            Assert.AreEqual(6, anchors.Count);
            Assert.AreEqual(ElementType.Body, anchors[0].Parent.Type);
            Assert.AreEqual(ElementType.Anchor, anchors[1].Parent.Type);
            Assert.AreEqual(ElementType.Body, anchors[2].Parent.Type);
            Assert.AreEqual(ElementType.Anchor, anchors[3].Parent.Type);
            Assert.AreEqual(ElementType.Anchor, anchors[4].Parent.Type);
            Assert.AreEqual(ElementType.UnorderedList, anchors[5].Parent.Type);
        }

        [Test]
        public void TestInsertFirstWorksCorrectly()
        {
            this._ulElement = new HtmlElement(ElementType.UnorderedList,
                           new HtmlElement(ElementType.ListItem),
                           new HtmlElement(ElementType.ListItem),
                           new HtmlElement(ElementType.ListItem)
                       );

            this._document = new DocumentObjectModel(
                new HtmlElement(ElementType.Document,
                    new HtmlElement(ElementType.Html,
                        new HtmlElement(ElementType.Head),
                        new HtmlElement(ElementType.Body,
                            new HtmlElement(ElementType.Paragraph),
                            new HtmlElement(ElementType.Div),
                            new HtmlElement(ElementType.Anchor,
                            this._ulElement
                        )
                    )
                )
            ));

            var h1Element = new HtmlElement(ElementType.H1);

            this._document.InsertFirst(this._ulElement, h1Element);

            Assert.AreEqual(4, this._ulElement.Children.Count);
            Assert.AreEqual(h1Element, this._ulElement.Children[0]);
            Assert.AreEqual(this._ulElement, h1Element.Parent);
        }

        [Test]
        public void TestInsertLastWorksCorrectly()
        {
            this._ulElement = new HtmlElement(ElementType.UnorderedList,
                           new HtmlElement(ElementType.ListItem),
                           new HtmlElement(ElementType.ListItem),
                           new HtmlElement(ElementType.ListItem)
                       );

            this._document = new DocumentObjectModel(
                new HtmlElement(ElementType.Document,
                    new HtmlElement(ElementType.Html,
                        new HtmlElement(ElementType.Head),
                        new HtmlElement(ElementType.Body,
                            new HtmlElement(ElementType.Paragraph),
                            new HtmlElement(ElementType.Div),
                            new HtmlElement(ElementType.Anchor,
                            this._ulElement
                        )
                    )
                )
            ));

            var h1Element = new HtmlElement(ElementType.H1);

            this._document.InsertLast(this._ulElement, h1Element);

            Assert.AreEqual(4, this._ulElement.Children.Count);
            Assert.AreEqual(h1Element, this._ulElement.Children[3]);
            Assert.AreEqual(this._ulElement, h1Element.Parent);
        }

        [Test]
        public void TestRemoveElementCorrectlyRemovesFromTheDom()
        {
            this._ulElement = new HtmlElement(ElementType.UnorderedList,
                          new HtmlElement(ElementType.ListItem),
                          new HtmlElement(ElementType.ListItem),
                          new HtmlElement(ElementType.ListItem)
                      );

            this._document = new DocumentObjectModel(
                new HtmlElement(ElementType.Document,
                    new HtmlElement(ElementType.Html,
                        new HtmlElement(ElementType.Head),
                        new HtmlElement(ElementType.Body,
                            new HtmlElement(ElementType.Paragraph),
                            new HtmlElement(ElementType.Div),
                            new HtmlElement(ElementType.Anchor,
                            this._ulElement
                        )
                    )
                )
            ));

            this._document.Remove(this._ulElement);

            var bodyEl = this._document.GetElementByType(ElementType.Body);
            Assert.AreEqual(3, bodyEl.Children.Count);
            Assert.IsFalse(this._document.Contains(this._ulElement));
        }

        [Test]
        public void TestRemoveAllElementsCorrectlyRemovesFromTheDom()
        {
            this._ulElement = new HtmlElement(ElementType.UnorderedList,
                           new HtmlElement(ElementType.ListItem),
                           new HtmlElement(ElementType.ListItem),
                           new HtmlElement(ElementType.ListItem)
                       );

            this._secondUlEmement = new HtmlElement(ElementType.UnorderedList,
                                new HtmlElement(ElementType.ListItem),
                                new HtmlElement(ElementType.ListItem),
                                new HtmlElement(ElementType.ListItem)
                            );

            this._thirdUlElement = new HtmlElement(ElementType.UnorderedList,
                                new HtmlElement(ElementType.ListItem),
                                new HtmlElement(ElementType.ListItem),
                                new HtmlElement(ElementType.ListItem)
                            );

            this._document = new DocumentObjectModel(
                new HtmlElement(ElementType.Document,
                    new HtmlElement(ElementType.Html,
                        new HtmlElement(ElementType.Head),
                        new HtmlElement(ElementType.Body,
                            new HtmlElement(ElementType.Paragraph, this._ulElement),
                            new HtmlElement(ElementType.Div, this._secondUlEmement),
                            new HtmlElement(ElementType.Anchor,
                            this._thirdUlElement
                        )
                    )
                )
            ));

            this._document.RemoveAll(ElementType.UnorderedList);

            var ulElements = this._document.GetElementsByType(ElementType.UnorderedList);
            Assert.IsEmpty(ulElements);
            Assert.IsFalse(this._document.Contains(this._ulElement));
            Assert.IsFalse(this._document.Contains(this._secondUlEmement));
            Assert.IsFalse(this._document.Contains(this._thirdUlElement));
        }

        [Test]
        public void TestAddAttributeRetursTrue()
        {
            this._ulElement = new HtmlElement(ElementType.UnorderedList,
                            new HtmlElement(ElementType.ListItem),
                            new HtmlElement(ElementType.ListItem),
                            new HtmlElement(ElementType.ListItem)
                        );

            this._document = new DocumentObjectModel(
                new HtmlElement(ElementType.Document,
                    new HtmlElement(ElementType.Html,
                        new HtmlElement(ElementType.Head),
                        new HtmlElement(ElementType.Body,
                            new HtmlElement(ElementType.Paragraph),
                            new HtmlElement(ElementType.Div),
                            new HtmlElement(ElementType.Anchor,
                            this._ulElement
                        )
                    )
                )
            ));

            var isAdded = this._document.AddAttribute("id", "navigation", this._ulElement);
            var ul = this._document.GetElementByType(ElementType.UnorderedList);

            Assert.IsTrue(isAdded);
            Assert.IsTrue(ul.Attributes.ContainsKey("id"));
            Assert.AreEqual("navigation", ul.Attributes["id"]);
        }

        [Test]
        public void TestRemoveAttributeRetursTrue()
        {
            this._ulElement = new HtmlElement(ElementType.UnorderedList,
                            new HtmlElement(ElementType.ListItem),
                            new HtmlElement(ElementType.ListItem),
                            new HtmlElement(ElementType.ListItem)
                        );

            this._document = new DocumentObjectModel(
                new HtmlElement(ElementType.Document,
                    new HtmlElement(ElementType.Html,
                        new HtmlElement(ElementType.Head),
                        new HtmlElement(ElementType.Body,
                            new HtmlElement(ElementType.Paragraph),
                            new HtmlElement(ElementType.Div),
                            new HtmlElement(ElementType.Anchor,
                            this._ulElement
                        )
                    )
                )
            ));

            this._document.AddAttribute("id", "navigation", this._ulElement);
            var isRemoved = this._document.RemoveAttribute("id", this._ulElement);
            var ul = this._document.GetElementByType(ElementType.UnorderedList);

            Assert.IsTrue(isRemoved);
            Assert.IsFalse(ul.Attributes.ContainsKey("id"));
        }

        [Test]
        public void TestGetElementByIdReturnsCorrectValue()
        {
            this._ulElement = new HtmlElement(ElementType.UnorderedList,
                            new HtmlElement(ElementType.ListItem),
                            new HtmlElement(ElementType.ListItem),
                            new HtmlElement(ElementType.ListItem)
                        );

            this._document = new DocumentObjectModel(
                new HtmlElement(ElementType.Document,
                    new HtmlElement(ElementType.Html,
                        new HtmlElement(ElementType.Head),
                        new HtmlElement(ElementType.Body,
                            new HtmlElement(ElementType.Paragraph),
                            new HtmlElement(ElementType.Div),
                            new HtmlElement(ElementType.Anchor,
                            this._ulElement
                        )
                    )
                )
            ));

            this._document.AddAttribute("id", "navigation", this._ulElement);

            var element = this._document.GetElementById("navigation");

            Assert.IsNotNull(element);
            Assert.AreEqual(this._ulElement, element);
        }

        [Test]
        public void TestToStringReturnsCorrectText()
        {
            this._ulElement = new HtmlElement(ElementType.UnorderedList,
                           new HtmlElement(ElementType.ListItem),
                           new HtmlElement(ElementType.ListItem),
                           new HtmlElement(ElementType.ListItem)
                       );

            this._document = new DocumentObjectModel(
                new HtmlElement(ElementType.Document,
                    new HtmlElement(ElementType.Html,
                        new HtmlElement(ElementType.Head),
                        new HtmlElement(ElementType.Body,
                            new HtmlElement(ElementType.Paragraph),
                            new HtmlElement(ElementType.Div),
                            new HtmlElement(ElementType.Anchor),
                            this._ulElement
                        )
                    )
                )
            );

            string domTree = "Document\r\n" +
                "  Html\r\n" +
                "    Head\r\n" +
                "    Body\r\n" +
                "      Paragraph\r\n" +
                "      Div\r\n" +
                "      Anchor\r\n" +
                "      UnorderedList\r\n" +
                "        ListItem\r\n" +
                "        ListItem\r\n" +
                "        ListItem";

            Assert.AreEqual(domTree, this._document.ToString().Trim());
        }
    }
}
