using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions {
	class Chapter3Problem6 : ICodingProblem {
		public void Run() {
			AnimalQueue shelter = new AnimalQueue();
			Dog fido = new Dog("Fido");
			Dog kona = new Dog("Kona");
			Cat kitty = new Cat("Kitty");
			Cat tigger = new Cat("Tigger");
			shelter.EnqueuAnimal(fido);
			shelter.EnqueuAnimal(kona);
			shelter.EnqueuAnimal(kitty);
			shelter.EnqueuAnimal(tigger);
			shelter.Print();
			Console.In.ReadLine();
			Cat animal = shelter.DequeueCat();
			Console.Out.WriteLine($"{animal.ToString()} was just adopted!");
			animal = shelter.DequeueCat();
			Console.Out.WriteLine($"{animal.ToString()} was just adopted!");
			animal = shelter.DequeueCat();
			Console.Out.WriteLine($"{animal?.ToString()} was just adopted!");
			shelter.Print();
			Console.In.ReadLine();

		}
		public enum AnimalType {
			Dog,
			Cat
		};
		public class Adoptable {
			public AnimalType AnimalType { get; set; }
			public string Name { get; set; }
		}
		public class Dog : Adoptable {
			public Dog(string name) {
				Name = name;
				AnimalType = AnimalType.Dog;

			}
			
			public override string ToString() {
				return $"{AnimalType}:{Name}";
			}
		}
		public class Cat : Adoptable {
			public Cat(string name) {
				Name = name;
				AnimalType = AnimalType.Cat;

			}

			public override string ToString() {
				return $"{AnimalType}:{Name}";
			}
		}

		public class Node<Adoptable> {
			public Node<Adoptable> next;
			public Adoptable data;
			public Node(Adoptable newData) {
				next = null;
				data = newData;
			}
		}		

		

		public class AnimalList {
			Node<Adoptable> head;
			public void appendToTail(Adoptable dataToAppend) {
				Node<Adoptable> node = this.head;
				if (node == null) {
					node = new Node<Adoptable>(dataToAppend);
					head = node;
				} else {
					while (node.next != null) {
						node = node.next;
					}
					var newNode = new Node<Adoptable>(dataToAppend);
					node.next = newNode;
				}
			}
			public void Print() {
				Node<Adoptable> cur = this.head;
				while (cur != null) {
					Console.Out.Write($"{cur.data}->");
					cur = cur.next;
				}
			}

			internal Adoptable RemoveFirst() {
				if (head == null) {
					return default(Adoptable);
				}
				Node<Adoptable> headData = head;
				head = head.next;
				return headData.data;
			}
			public Adoptable RemoveSpecificType(AnimalType typeToRemove) {
				Node<Adoptable> adoptee = head;
				Node<Adoptable> prev = null;
				while(adoptee != null && adoptee.data.AnimalType != typeToRemove) {
					prev = adoptee;
					adoptee = adoptee.next;
				}
				if(adoptee == null) {
					Console.Out.WriteLine("Animal type not detected");
					return null;
				}
				prev.next = adoptee.next;
				return adoptee.data;

			}

		}
		

		public class AnimalQueue {
			public AnimalList animalList = new AnimalList();

			public void EnqueuAnimal(Adoptable animal) {
				animalList.appendToTail(animal);
			}
			public Adoptable DequeueAnimal() {
				return animalList.RemoveFirst();
			}
			public Cat DequeueCat() {
				return (Cat)animalList.RemoveSpecificType(AnimalType.Cat);
			}
			public void Print() {
				animalList.Print();
			}
			public Dog DequeueDog() {
				return (Dog)animalList.RemoveSpecificType(AnimalType.Dog);
			}



		}
	}
}
