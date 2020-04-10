//: Playground - noun: a place where people can play

import UIKit

var str = "Hello, playground"
var test = 43

//TestClass testClass
//testClass = new TestClass()

print(str)

var myArray = [Int]()
myArray.append(3)
myArray.append(4)

for number in myArray {
    print(number)
}

let aPerson = Person(firstName: "Jacob", lastName: "Edwards")
let anotherPerson = Person(firstName: "Candance", lastName: "Salinas")

aPerson.sayHello();
anotherPerson.sayHello();

struct Person {
    let firstName: String
    let lastName: String
    
    func sayHello() {
        print("Hello there! My name is: \(firstName) \(lastName)." )
    }
}
