using Moq;
using SimpleSoundboard.Keyboard.NameService;
using System.Windows.Forms;

namespace SimpleSoundboard.Keyboard.Tests
{
    public class KeyboardControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }


        public IKeyEventArgs MockKeyEvent(Keys key, KeyState keyState, string keyboard= "UnitTestKeyboard")
        {
            var mock = new Mock<IKeyEventArgs>();
            mock.Setup(m => m.KeyCode).Returns(key);
            mock.Setup(m => m.KeyState).Returns(keyState);
            mock.Setup(m => m.UniqueName).Returns(keyboard);
            return mock.Object;
        }

        [TestCase(new Keys[] { Keys.Up })]
        [TestCase(new Keys[] { Keys.Up,Keys.A })]
        [TestCase(new Keys[] { Keys.Up,Keys.A,Keys.B })]
        [TestCase(new Keys[] { Keys.Up, Keys.A, Keys.Down })]
        public void OnKeyEvent_Should_Fire_Action(IEnumerable<Keys> keys)
        {
            bool fired=false;
            void OnFired()
            {
                fired=true;
            }
            var keyboardController = new KeyboardController();
            keyboardController.RegisterKeyAction(keys, OnFired);
            foreach(var key in keys)
            {
                keyboardController.OnKeyEvent(null, MockKeyEvent(key,KeyState.Pressed));
            };

            foreach (var key in keys)
            {
                keyboardController.OnKeyEvent(null, MockKeyEvent(key, KeyState.Released));
            };

            Assert.IsTrue(fired);
        }
    }
}