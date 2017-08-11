using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions {
	class Chapter3Problem6 : ICodingProblem {
		public void Run() {
			AnimalQueue shelter = new AnimalQueue();
			Animal myDog1 = new Animal("Fido", AnimalType.Dog);
			Animal myDog2 = new Animal("Kona", AnimalType.Dog);
			Animal myCat1 = new Animal("Kitty1", AnimalType.Cat);
			Animal myCat2 = new Animal("Kitty2", AnimalType.Cat);
			shelter.EnqueuAnimal(myDog1);
			shelter.EnqueuAnimal(myDog2);
			shelter.EnqueuAnimal(myCat1);
			shelter.EnqueuAnimal(myCat2);
			shelter.Print();
			Console.In.ReadLine();
			Animal animal = shelter.DequeueCat();
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
		public interface Adoptable {
			AnimalType GetAnimalType();
			string GetName();
		}
		public class Animal : Adoptable {
			public AnimalType Type { get; set; }
			public string Name { get; set; }
			public Animal(string name, AnimalType type) {
				Name = name;
				Type = type;
			}
			public override string ToString() {
				return $"{Type}:{Name}";
			}

			public AnimalType GetAnimalType() { 
				return Type;
			}

			public string GetName() {
				return Name;
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

		

		public class AnimalList<Adoptable> {
			Node<Animal> head;
			public void appendToTail(Animal dataToAppend) {
				Node<Animal> node = this.head;
				if (node == null) {
					node = new Node<Animal>(dataToAppend);
					head = node;
				} else {
					while (node.next != null) {
						node = node.next;
					}
					var newNode = new Node<Animal>(dataToAppend);
					node.next = newNode;
				}
			}
			public void Print() {
				Node<Animal> cur = this.head;
				while (cur != null) {
					Console.Out.Write($"{cur.data}->");
					cur = cur.next;
				}
			}

			internal Animal RemoveFirst() {
				if (head == null) {
					return default(Animal);
				}
				Node<Animal> headData = head;
				head = head.next;
				return headData.data;
			}
			public Animal RemoveSpecificType(AnimalType typeToRemove) {
				Node<Animal> adoptee = head;
				Node<Animal> prev = null;
				while(adoptee != null && adoptee.data.GetAnimalType() != typeToRemove) {
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
			public AnimalList<Animal> animalList = new AnimalList<Animal>();

			public void EnqueuAnimal(Animal animal) {
				animalList.appendToTail(animal);
			}
			public Animal DequeueAnimal() {
				return animalList.RemoveFirst();
			}
			public Animal DequeueCat() {
				return animalList.RemoveSpecificType(AnimalType.Cat);
			}
			public void Print() {
				animalList.Print();
			}
			public Animal DequeueDog() {
				return animalList.RemoveSpecificType(AnimalType.Dog);
			}



		}
	}
}
