# Product extension process

I am not really good at following "agreed minimum". I tend to sabotage myself with figuring out new features while creating certain functionality and it mostly ends in "context switch". This is something that caused me a failure in multiple recruiting processes. I will try to adress this problem of mine in this project by following incremental extensions of the product. Concretely, I will decide on the set of features that have to be implemented in targeted version of the product and implement nothing else (kinda more strict sprints?).

# Feature implementation strategy

I would like to stick to one specific feature implementation strategy throughout creating this project. In my software development adventure I caught myself way too many times trying to squeeze too many changes into one branch or even one commit. I don't consider it odd. I'd rather say that it is actually pretty standard, but I would like to try avoiding it and try to keep this repo as clean as possible.

The strategy:

<ol>
  <li>Target version branch,</li>
  <li>Feature branch derived from the current target version branch,</li>
  <li>Feature testing branch derived from the target feature, once the feature is completed.</li>
</ol>

That <b>should</b> potentially work. If it didn't on a long run; I will most likely have more insight to properly adjust this strategy.
