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
	- generate key from MD5 or in db (all hash result are too long)
	- check collisions (can live with that?)
	- parallel process to retire slugs, put them into FIFO queue (oldest are the shortest ones)
	- collisions in distributed db 
	- could pre-generate/reserve lists of keys in sclaed environment
	- could be custom primary key generator (0-1 A-Z)
	- caching probably doesn't make much sense (depends how the urls are used)
	
- api versioning
	- changes in db 
		- migration of old data in background
		- switching to new database
		- 
		
- todo
	- logging
	- monitoring
	