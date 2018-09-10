# Start from a core stack version
FROM jupyter/scipy-notebook
# Install from requirements.txt file
COPY requirements.txt /tmp/
RUN pip install --requirement /tmp/requirements.txt && \
    fix-permissions $CONDA_DIR && \
    fix-permissions /home/$NB_USER

CMD ["start-notebook.sh"]
