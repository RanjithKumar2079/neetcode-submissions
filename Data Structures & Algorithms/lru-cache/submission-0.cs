public class LRUCache {
    // Doubly linked list node structure
    private class DNode {
        public int key;
        public int val;
        public DNode prev;
        public DNode next;
        
        public DNode(int k = 0, int v = 0) {
            key = k;
            val = v;
        }
    }

    private int capacity;
    private Dictionary<int, DNode> map;
    private DNode head;
    private DNode tail;

    public LRUCache(int capacity) {
        this.capacity = capacity;
        this.map = new Dictionary<int, DNode>();
        
        // Initialize dummy head and tail to eliminate boundary edge cases
        head = new DNode();
        tail = new DNode();
        head.next = tail;
        tail.prev = head;
    }
    
    public int Get(int key) {
        if (!map.ContainsKey(key)) {
            return -1;
        }
        
        DNode node = map[key];
        // Accessing makes it the most recently used -> move to head
        MoveToHead(node);
        return node.val;
    }
    
    public void Put(int key, int value) {
        if (map.ContainsKey(key)) {
            // Update existing value and mark as recently used
            DNode node = map[key];
            node.val = value;
            MoveToHead(node);
        } else {
            // Create a new node
            DNode newNode = new DNode(key, value);
            
            // Check if we are at capacity and need to evict the LRU item
            if (map.Count >= capacity) {
                DNode lru = PopTail();
                map.Remove(lru.key);
            }
            
            // Add to dictionary and insert right at the front of the list
            map[key] = newNode;
            AddNode(newNode);
        }
    }
    
    // --- Helper Methods for Doubly Linked List Manipulation ---
    
    // Inserts a node right after the dummy head (Most Recently Used position)
    private void AddNode(DNode node) {
        node.prev = head;
        node.next = head.next;
        
        head.next.prev = node;
        head.next = node;
    }
    
    // Unlinks a node from its current position in the list
    private void RemoveNode(DNode node) {
        DNode prevNode = node.prev;
        DNode nextNode = node.next;
        
        prevNode.next = nextNode;
        nextNode.prev = prevNode;
    }
    
    // Refreshes a node's position by cutting it and moving it to the front
    private void MoveToHead(DNode node) {
        RemoveNode(node);
        AddNode(node);
    }
    
    // Removes and returns the node right before the dummy tail (Least Recently Used position)
    private DNode PopTail() {
        DNode lruNode = tail.prev;
        RemoveNode(lruNode);
        return lruNode;
    }
}
