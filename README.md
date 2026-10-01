# 🎤 Fearless Front VR

**Using Virtual Reality and AI to tackle a health challenge: overcoming public speaking anxiety.**  
*Project developed during the VR/AR Hackathon organized by Vidzemes Augstskola (Vidzeme University of Applied Sciences).*

## 📖 About the Project

Public speaking is one of the most common phobias and sources of stress. **Fearless Front VR** is an immersive virtual reality application designed to help users better manage their anxiety.

Immersed via a **Meta Quest 2** headset into a virtual classroom, the user faces a dynamic and realistic audience. The goal is to recreate progressive exposure conditions to help them conquer stage fright. At the end of the session, an **AI coach** analyzes the simulation data to generate personalized feedback.

## ✨ Key Features & Technical Architecture

Developed under **Unity 6**, the project integrates several advanced technological layers:

*   **Dynamic Crowd Reactions:** A lightweight system of randomized and asynchronous animations combined with gaze tracking (*Inverse Kinematics*) allows the audience to react in real-time (applause, murmurs, attentive listening).
*   **Biometric Data:** Real-time heart rate capture and tracking to assess the speaker's stress level.
*   **AI Coaching:** Integration of an artificial intelligence model via **Groq** and **Llama 3.3** to debrief the user's performance.
*   **Virtual Reality:** **OpenXR** configuration optimized for the Meta Quest 2.

## 🛠️ Tech Stack

*   **Engine:** Unity 6 (OpenXR, XR Interaction Toolkit)
*   **Language:** C#
*   **Artificial Intelligence:** Groq API / Llama 3.3
*   **Target Hardware:** Meta Quest 2
*   **3D / Animation:** FBX/GLTF formats, Humanoid Rigging (Mixamo)

## 🧠 Technical Challenges Overcome

1.  **VR Crowd Optimization:** Centralized the animation logic via a C# manager script to prevent performance hits on the headset while eliminating "T-Pose" bugs and skeleton synchronization issues.
2.  **XR Pipeline & Biofeedback:** Seamless connection between VR hardware, physiological tracking (heart rate), and cloud AI services.
3.  **Immersion & Presence:** Resolved 3D import issues (textures, materials) to ensure a clean, non-intrusive aesthetic conducive to stress reduction.

## 🚀 Installation & Usage

1. Clone this repository:
   ```bash
   git clone [https://github.com/JakubKula1/VR-hackathon-fearless-front.git](https://github.com/JakubKula1/VR-hackathon-fearless-front.git)
