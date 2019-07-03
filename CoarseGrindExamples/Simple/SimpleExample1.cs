
using System;
using System.Collections.Generic;
using Rockabilly.CoarseGrind.Descriptions;
using Rockabilly.Common;

namespace Rockabilly.CoarseGrind.Examples
{
	public class SimpleExample1 : Test
	{

		public override string DetailedDescription
		{
			get
			{
				return "This is the detailed description for SimpleExample1.  Use this field to describe what the test does and what its pass criteria are. Commas, \tTabs, \rCarriage Returns, \nLine Feeds, and \fForm Feed chars will be filtered out.";
			}
		}

		public override void PerformTest()
		{
			// This would be where you actually perform the test.  What a surprise, huh?
			// If setup fails, it will NOT be run.

			int percentSetup = 100;
			CheckPrerequisite("Verifying that everything is setup.", percentSetup == 100);

			// Coarse Grind does not interrupt the test if something fails.
			// This is by-design to support multiple points-of-failure.
			// If inconclusive or failing status makes it pointless to proceed, you must explicitly enforce that.
			if (this.OverallStatus != TestStatus.Inconclusive)
			{
				// You should log every little thing the test does.  That lessens the chance of needing to re-run when a bug happens.
				Log.Info("Calling doSomethingOne()");
				//int return1 = doSomethingOne();
				int return1 = 42;

				Log.Info("Calling doSomethingTwo()");
				//int return2 = doSomethingTwo();
				int return2 = 42;

				Log.Info("Calling doSomethingThree()");
				//doSomethingThree();

				CheckPassCriterion("Everything adds up nicely.", return1 + return2 == 84);
			}

            // This test should pass.
            // Note that the test subject will only be passing if there are NO failing or inconclusive tests in its contents.
        }

        public override bool Cleanup()
        {
            // This will ALWAYS be run, even if setup failed.
            Log.Info("Cleaning everything up...");
            Log.Debug("You don't have to have a Cleanup() method. If the Cleanup() returns false it has no affect programmatically, but will be indicated in the logs by the color of its section.");
            return true;
        }

        public override string Identifier
		{
			get
			{
				// This can be anything but is typically a number generated by a test case management system.
				// It is generally easier to say that "Test ST7 failed" than "The string-based selection upper limit test failed."
				return "ST1";
			}
		}


		public override string Name
		{
			get
			{
				// This should be a human-readable name that describes the test in-brief
				return "Sample Test ONE";
			}
        }

        public override bool Setup()
        {
            // Perform any test case specific setup.
            // If this does not return true, performTest() will never be run.
            // You may wish to make an abstract class that extends Test.
            // Lots of testcases could extend that and share the same setup(),
            // cleanup(), and other common methods.
            Log.Info("Setting this up...");
            Log.Info("Setting that up...");
            Log.Info("Setting up one more thing...");
            Log.Debug("You don't have to have a Setup() method. If the Setup() returns false the PerformTest() method <b><u>WILL NOT BE RUN!!!</u></b>. Any Cleanup() method will be run regardless of whether or not Setup() failed.");
            return true;
        }

        public override string[] TestCategoryMemberships
		{
			get
			{
				return new String[] { "Simple", "All", "Example" };
			}
		}

	}
}