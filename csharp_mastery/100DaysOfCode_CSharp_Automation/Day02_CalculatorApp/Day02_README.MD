# Day 2 - Write N UNit test to verify exception
**Goal: Extend the Calculator with Multiply and Divide methods and write NUnit tests including division by zero handling.**
**Tasks:**  
- [x] Add Multiply and Divide methods
- [x] Handle divide-by-zero with exception
- [x] Update NUnit tests to cover new methods and edge cases

## Summary of Learning & Cheat sheet 
```Csharp
[Test]
        public void DivideByZeroThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => Calculator.Divide(10, 0));
        }
```