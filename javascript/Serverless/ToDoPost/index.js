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
        const result = await db.collection(collectionName).insert(
            req.body
        );

        console.log(`result => ${JSON.stringify(result)}`);
        console.log(`res => ${JSON.stringify(req.body)}`);

        response = {
            status: 201,
            body: result,
            headers: {
                'Content-Type': 'application/json'
            }
        };
    }
    finally {
        client.close();
        context.res = response;
        //context.done();

        return response;
        s
    }
}

/*
async function (context, req) {
  context.log('Running');

  mongodb.MongoClient.connect(uri, function(error, client) {
    if (error) {
      context.log('Failed to connect');
      context.res = { status: 500, body: res.stack }
      return context.done();
    }
    context.log(req.body);
    context.log('Connected');

    let json = JSON.parse(req.body);
    context.log('Detected ' + json.length + ' incoming documents');

    try
    {
        //context.bindings.documentsToStore = [];
        //for(let i = 0, len=json.length; i<len;i++){
        //    const doc = json[i];
            //context.bindings.documentsToStore.push(doc);
        //    client.db('ToDos').collection('MyToDos').push(doc);
        //}
    }
    catch(ex){
        context.log('Failed to save');
        context.res = { status: 500, body: res.stack };

        //return context.done();
    } finally {
        client.close();

        context.res = {
            status: 200,
            body: "Completed"
        };
        //context.done();
    }
    //, {
    //        status: 201, body: 'Processed ' + req.body.length + ' documents'
    //    });
  });
};

*/