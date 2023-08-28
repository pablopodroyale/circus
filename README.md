We need to create a circus app, the client can choose four animal categories for the show: Cat, Dog, Monkey, and Bird
Once the client press show(Circus.show())  the app randomly blends the 4 animals, in such a way Bob the Dog might behave like a Bird...
The approach was takenn from the chain of responsability pattern
https://refactoring.guru/design-patterns/chain-of-responsibility/csharp/example
Each animal is responsible to emit its sound. This approach allow the animal to imitate others animal without exposing the bahavior.