import os
from deepface import DeepFace
import time
import json

# Folder path
path = r'C:\Users\billt\Documents\GitHub\Gambling-Emotions\Misc'
# List to store frame names
frames = []
# Sequence of emotions
sequence = []
# Dictionary of emotional occurences
emotions = {'angry': 0, 'disgust': 0, 'fear': 0, 'happy': 0, 'sad': 0, 'surprise': 0, 'neutral': 0}

start = time.time()

# Iterate directory
for pic in os.listdir(path):
    frames.append(pic)

# Analyze each frame
for pic in frames:
    analysis = DeepFace.analyze(img_path = 'frames/' + pic, enforce_detection=False)
    # Count occurences
    if analysis['dominant_emotion'] == 'angry':
        sequence.append('angry')
        emotions['angry'] += 1
    elif analysis['dominant_emotion'] == 'disgust':
        sequence.append('disgust')
        emotions['disgust'] += 1
    elif analysis['dominant_emotion'] == 'fear':
        sequence.append('fear')
        emotions['fear'] += 1
    elif analysis['dominant_emotion'] == 'happy':
        sequence.append('happy')
        emotions['happy'] += 1
    elif analysis['dominant_emotion'] == 'sad':
        sequence.append('sad')
        emotions['sad'] += 1
    elif analysis['dominant_emotion'] == 'surprise':
        sequence.append('surprise')
        emotions['surprise'] += 1
    else:
        sequence.append('neutral')
        emotions['neutral'] += 1

# Print results
with open('data.txt', 'a') as file:
    file.write('\n' + json.dumps(sequence) + '\n' + json.dumps(emotions) + '\n')

print('%s sec.' %(time.time() - start))
