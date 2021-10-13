# AsyncEventHandler

Simple way to ensure all async event handlers (delegates) are awaited.

This is necessary because C# events are unable to await async event handlers (instead they are executed in fire-and-forget fashion). This is because events existed in the language well before the async-await pattern was introduced. An event is just simply a list of event handlers (or delegates or callbacks) and when the event is raised, the event handlers are invoked sequentially (i.e. one after the other).
