# ActionerDemo
Writing a class which completes work in the background without blocking a programs execution can be achieved easily using the async/await pattern with Tasks. However limiting concurrency by ensuring these background processes run one at a time, in sequence, potentially added in different threads at different times does add a reasonable level of complexity. 

Initially I had thought to create a thread safe Singleton class using a lock as per the MSDN docs - https://msdn.microsoft.com/en-gb/library/ff650316.aspx, using a queue collection would ensure that the processes are run in the correct order, however there is a gotcha with this solution, I could not ensure the processes ran one at a time without awaiting the tasks inside the lock. This throws a compiler error, because of the possibility of deadlocks. 

Enter the Semaphore class, which is used for managing resources, my favourite analogy which describes a Semaphore is from Joe Albahari. "A semaphore is like a nightclub: it has a certain capacity, enforced by a bouncer. Once it’s full, no more people can enter, and a queue builds up outside. Then, for each person that leaves, one person enters from the head of the queue. The constructor requires a minimum of two arguments: the number of places currently available in the nightclub and the club’s total capacity."  

This solution is wrapped in a simple WPF project with one view, and one view-model, which binds three buttons to delegate commands to invoke the background work and logs the output to a textbox. 
