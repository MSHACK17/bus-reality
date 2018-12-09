## Running notebooks with Docker
To run the notebooks in a ready to use Docker environment run

    $ docker-compose up

Go to [127.0.0.1:8888](127.0.0.1:8888) and enter the token from the console.
All the notebooks should be ready to be executed in Jupyter lab.

## Installing dependencies
Instead of a running the notebook on a Docker image, you can install the necessary packages via pip.

    $ pip install -r requirements.txt
    
## Converting the notebooks to a book

As HTML version

    $ python -m bookbook.html   

As PDF version

    $ python -m bookbook.latex --pdf --template wrap_article   
