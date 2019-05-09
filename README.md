# shortener
Url Shortener PoC

- questions
	- how many urls
	- throughput
	- what is availability
	- maximum for a user?
	- what is a viable percent of collisions
	- availability, failure

- scaling	
	- use NoSql database /?
	- generate key from MD5 or in db
	- check collisions (can live with that?)
	- if we need it as short as possible we need to have a database with empty keys
	- collisions in distributed db 
	- could pre-generate/reserve lists of keys in sclaed environment
	- could be custom primary key generator (0-1 A-Z)
	
- api versioning
	- changes in db 
		- migration of old data in background
		- switching to new database
		- 
		
- todo
	- logging
	- monitoring
	