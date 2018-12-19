# Machine Learning and Bus Delay Prediction
In this repository you find the revised bus delay prediction from the MünsterHack 2017.

* the `*.ipynb` files contain the executable code
* `combined.pdf` contains theoretical background and code as single document
* `html` contains theoretical background and code as HTML documents

## Running notebooks with Docker
To run the notebooks in a ready to use environment run

    $ docker-compose up

Go to [127.0.0.1:8888](127.0.0.1:8888) and enter the token from the console.
All the notebooks should be ready to be executed in JupyterLab.

## Installing dependencies
Instead of a running the notebook on a Docker image, you can install the necessary packages via pip.

    $ pip install -r requirements.txt
    
## Converting the notebooks to a book

As HTML version

    $ python -m bookbook.html   

As PDF version

    $ python -m bookbook.latex --pdf --template wrap_article   
