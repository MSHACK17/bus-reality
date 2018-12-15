#!/bin/bash
jupyter nbconvert --execute --allow-errors --inplace <lecture.ipynb> 
jupyter nbconvert --execute  --inplace 01-cleaning.ipynb
jupyter nbconvert --execute  --inplace 02-weather_feature.ipynb
jupyter nbconvert --execute  --inplace 03-holidays_feature.ipynb
jupyter nbconvert --execute  --inplace 04-feature_merging.ipynb
jupyter nbconvert --execute  --inplace 05-feature_preprocessing.ipynb
jupyter nbconvert --execute  --inplace --ExecutePreprocessor.timeout=180 06-prediction.ipynb