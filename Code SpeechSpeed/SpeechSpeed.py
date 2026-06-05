import speech_recognition as sr
import time
import socket

### Network config
UDP_IP = "127.0.0.1"
UDP_PORT_WPM = 5051  # Port (need to be the same with unity)
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

# Initialize the voice recognition
r = sr.Recognizer()

def listen_and_calculate_wpm():
    # Using default microphone
    with sr.Microphone() as source:
        print("Adjusting noise arround (Wait 2s)...")
        r.adjust_for_ambient_noise(source, duration=2)
        print("✅ Ready ! Speech in english.")

        while True:
            try:
                # Listening of the sentence
                print("\nListening...")
                start_time = time.time()

                # cutting after 10 second to send data on regular way
                audio = r.listen(source, timeout=5, phrase_time_limit=10)
                end_time = time.time()

                print("Treating data ...")
                # Using of google API to find the word
                text = r.recognize_google(audio, language="en-US")

                # Word count
                word_count = len(text.split())
                duration_seconds = end_time - start_time

                # WPM
                if duration_seconds > 0:
                    wpm = int((word_count / duration_seconds) * 60)
                    print(f"Sentence: '{text}'")
                    print(f"Words: {word_count} | Time: {duration_seconds:.1f}s -> Speed: {wpm} WPM")

                    # Sending to unity
                    sock.sendto(str(wpm).encode('utf-8'), (UDP_IP, UDP_PORT_WPM))

            except sr.UnknownValueError:
                print("Voice failed to be recognized.")
            except sr.WaitTimeoutError:
                pass # Nothing was said
            except Exception as e:
                print(f"Microphone ERROR : {e}")

if __name__ == "__main__":
    try:
        listen_and_calculate_wpm()
    except KeyboardInterrupt:
        print("\nProgramme ended.")