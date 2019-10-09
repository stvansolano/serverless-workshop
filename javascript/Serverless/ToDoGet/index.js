
let MongoClient = require('mongodb').MongoClient;

const connectionString = process.env['MongoDbConnection'];

module.exports = async function (context, req) {
    context.log('Running');
    console.log(`Using connection string:${connectionString}`);

    let client = await MongoClient.connect(connectionString,
        { useNewUrlParser: true });

    let db = client.db('ToDos');
    let collectionName = process.env['MongoDbCollection'];
    let response = {};

    console.log(`Using collectionName string:${collectionName}`);

    try {
        const result = await db.collection(collectionName)
                               .find({}, { name: 1, _id: 1 })
                               .toArray();

        console.log(`result => ${JSON.stringify(result)}`);
        console.log(`res => ${JSON.stringify(req.body)}`);

        response = {
            status: 200,
            body: result,
            headers: {
                'Content-Type': 'application/json'
            }
        };
    }
    catch(error){
        console.log(error);
    }
    finally {
        context.res = response;
        client.close();
        //context.done();

        return response;
    }
};