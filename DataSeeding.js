// Switch to your database
use LHS-WEBAPP_DB;

db.createCollection("test", {
    validator: {
        $jsonSchema: {
            bsonType: "object",
            required: ["name", "email", "age"],
            properties: {
                name: {
                    bsonType: "string",
                    description: "Must be a string and is required"
                },
                email: {
                    bsonType: "string",
                    pattern: "^.+@.+$", // Ensures email format
                    description: "Must be a valid email address"
                },
                age: {
                    bsonType: "int",
                    minimum: 18,
                    description: "Must be an integer and at least 18"
                },
                isAdmin: {
                    bsonType: "bool",
                    description: "Optional boolean field"
                }
            }
        }
    }
})

// Insert multiple documents into the 'users' collection
db.test.insertMany([
    { "_id": ObjectId("67e3b6de676d2035e9b6bac7"), "name": "Pubububububu", "email": "alice@example.com" },
    { "_id": ObjectId("67e3b6de676d2035e9b6bac8"), "name": "Bob", "email": "bob@example.com" }
]);