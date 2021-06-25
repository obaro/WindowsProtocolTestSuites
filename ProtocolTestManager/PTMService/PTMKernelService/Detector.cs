// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Protocols.TestManager.Detector;
using Microsoft.Protocols.TestManager.PTMService.Common.Types;
using Microsoft.Protocols.TestManager.PTMService.Abstractions.Kernel;

namespace Microsoft.Protocols.TestManager.PTMService.PTMKernelService
{
    /// <summary>
    /// This class represents the engine for the auto-detection.
    /// </summary>
    public class Detector
    {
        private CancellationTokenSource cts = new CancellationTokenSource();
        
        private IValueDetector detector = null;

        private Task detectTask = null;

        private bool taskCanceled = false;

        /// <summary>
        /// Delegate of logging.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="style"></param>
        public delegate void DetectLog(string message, LogStyle style);

        /// <summary>
        /// Instance of DetectLog.
        /// </summary>
        public DetectLog DetectLogCallback;

        public void Reset()
        {
            if (detector != null) detector.Dispose();
            detector = null;
            UtilCallBackFunctions.WriteLog = (message, newline, style) =>
                {
                    if (DetectLogCallback != null) DetectLogCallback(message, style);
                };
        }

        /// <summary>
        /// Loads the auto-detect plug-in from assembly file.
        /// </summary>
        /// <param name="detectorAssembly">File name</param>
        public void Load(string detectorAssembly)
        {
            Reset();

            // Get CustomerInterface
            Type interfaceType = typeof(IValueDetector);

            Assembly assembly = Assembly.LoadFrom(detectorAssembly);

            Type[] types = assembly.GetTypes();

            // Find a class that implement Customer Interface
            foreach (Type type in types)
            {
                if (type.IsClass && interfaceType.IsAssignableFrom(type) == true)
                {
                    // Create an instance
                    detector = assembly.CreateInstance(type.FullName) as IValueDetector;
                }
            }
            if (detector == null) throw new Exception(AutoDetectionConsts.LoadingAutoDetectorFailed);
        }

        /// <summary>
        /// Gets the properties required for auto-detection.
        /// </summary>
        /// <returns>Prerequisites object.</returns>
        public Prerequisites GetPrerequisits()
        {
            return detector.GetPrerequisites();
        }

        /// <summary>
        /// Gets a list of the detection steps.
        /// </summary>
        /// <returns>A list fo the detection steps.</returns>
        public List<DetectingItem> GetDetectSteps()
        {
            return detector.GetDetectionSteps();
        }

        private DetectionOutcome RunDetection()
        {
            try
            {
                detector.RunDetection();
            }
            catch (Exception exception)
            {
                return new DetectionOutcome(DetectionStatus.Error, exception);
            }
            return new DetectionOutcome(DetectionStatus.Finished, null);
        }

        /// <summary>
        /// Begins the auto-detection.
        /// </summary>
        /// <param name="DetectionEvent">Callback function when the detection finished.</param>
        public void BeginDetection(DetectionCallback DetectionEvent)
        {
            var token = cts.Token;

            token.Register(() => {
                taskCanceled = true;
            });

            detectTask = new Task(() =>
            {
                token.ThrowIfCancellationRequested();

                var outcome = RunDetection();

                if (DetectionEvent != null)
                {
                    DetectionEvent(outcome);
                }
            }, token);

            detectTask.Start();
        }

        /// <summary>
        /// Stop the auto-detection
        /// </summary>
        public void StopDetection(Action callback)
        {
            if (detectTask != null)
            {
                cts.Cancel();
                while(!taskCanceled)
                {
                    Thread.SpinWait(100);
                }

                if (callback != null)
                {
                    callback();
                }

                detectTask = null;
            }
            
            taskCanceled = false;
        }

        /// <summary>
        /// Sets the values of the properties required for auto-detection.
        /// </summary>
        /// <param name="properties">Name - value map.</param>
        /// <returns>Returns true if provided values are enough, otherwise returns false.</returns>
        public bool SetPrerequisites(Dictionary<string,string> properties)
        {
            return detector.SetPrerequisiteProperties(properties);
        }

        /// <summary>
        /// Gets an object represents the detection summary.
        /// </summary>
        /// <returns>An object</returns>
        public object GetDetectionSummary()
        {
            return detector.GetSUTSummary();
        }

        /// <summary>
        /// Gets the case selection rules suggested by the detector.
        /// </summary>
        /// <returns>A list of the rules</returns>
        public List<CaseSelectRule> GetRules()
        {
            return detector.GetSelectedRules();
        }

        /// <summary>
        /// Gets a list of properties to hide.
        /// </summary>
        /// <param name="rules">Test case selection rules</param>
        /// <returns>A list of properties to hide.</returns>
        public List<string> GetHiddenProperties(List<CaseSelectRule> rules)
        {
            return detector.GetHiddenProperties(rules);
        }

        /// <summary>
        /// Gets the property values detected by the detector.
        /// </summary>
        /// <returns>Name - value / values map.</returns>
        public Dictionary<string, List<string>> GetDetectedProperty()
        {
            Dictionary<string, List<string>> dict;
            detector.GetDetectedProperty(out dict);
            return dict;
        }
    }
}